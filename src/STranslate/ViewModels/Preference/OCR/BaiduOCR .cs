﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STranslate.Model;
using STranslate.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace STranslate.ViewModels.Preference.OCR
{
    public partial class BaiduOCR : ObservableObject, IOCR
    {
        #region Constructor

        public BaiduOCR()
            : this(Guid.NewGuid(), "https://aip.baidubce.com", "百度OCR") { }

        public BaiduOCR(
            Guid guid,
            string url,
            string name = "",
            IconType icon = IconType.Baidu2,
            string appID = "",
            string appKey = "",
            bool isEnabled = true,
            OCRType type = OCRType.BaiduOCR
        )
        {
            Identify = guid;
            Url = url;
            Name = name;
            Icon = icon;
            AppID = appID;
            AppKey = appKey;
            IsEnabled = isEnabled;
            Type = type;
        }

        #endregion Constructor

        #region Properties

        [ObservableProperty]
        private Guid _identify = Guid.Empty;

        [JsonIgnore]
        [ObservableProperty]
        private OCRType _type = OCRType.BaiduOCR;

        [JsonIgnore]
        [ObservableProperty]
        public bool _isEnabled = true;

        [JsonIgnore]
        [ObservableProperty]
        private string _name = string.Empty;

        [JsonIgnore]
        [ObservableProperty]
        private IconType _icon = IconType.Baidu2;

        [JsonIgnore]
        [ObservableProperty]
        [property: DefaultValue("")]
        [property: JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _url = string.Empty;

        [JsonIgnore]
        [ObservableProperty]
        [property: DefaultValue("")]
        [property: JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _appID = string.Empty;

        [JsonIgnore]
        [ObservableProperty]
        [property: DefaultValue("")]
        [property: JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _appKey = string.Empty;

        [JsonIgnore]
        public Dictionary<IconType, string> Icons { get; private set; } = ConstStr.ICONDICT;

        #region Show/Hide Encrypt Info

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _idHide = true;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _keyHide = true;

        private void ShowEncryptInfo(string? obj)
        {
            if (obj == null)
                return;

            if (obj.Equals(nameof(AppID)))
            {
                IdHide = !IdHide;
            }
            else if (obj.Equals(nameof(AppKey)))
            {
                KeyHide = !KeyHide;
            }
        }

        private RelayCommand<string>? showEncryptInfoCommand;

        [JsonIgnore]
        public IRelayCommand<string> ShowEncryptInfoCommand => showEncryptInfoCommand ??= new RelayCommand<string>(new Action<string?>(ShowEncryptInfo));

        #endregion Show/Hide Encrypt Info

        #endregion Properties

        #region Interface Implementation

        public async Task<OcrResult> ExecuteAsync(byte[] bytes, CancellationToken cancelToken)
        {
            var token = await GetAccessTokenAsync(AppID, AppKey, cancelToken);
            var suffix = $"/rest/2.0/ocr/v1/general?access_token={token}";
            var url = Url.TrimEnd('/') + suffix;
            var headers = new Dictionary<string, string[]>
            {
                { "Content-Type", [ "application/x-www-form-urlencoded" ]},
                { "Accept", ["application/json"]}
            };
            var base64Str = Convert.ToBase64String(bytes);
            var queryParams = new Dictionary<string, string[]>
            {
                {"image", [ base64Str ] },
                {"detect_direction", ["false"] },
                {"detect_language", ["false"] },
                {"vertexes_location", ["false"] },
                {"paragraph", ["false"] },
                { "probability", ["false"] },
            };
            var resp = await HttpUtil.PostAsync(url, headers, queryParams, cancelToken);
            if (string.IsNullOrEmpty(resp))
                throw new Exception("请求结果为空");

            // 解析JSON数据
            var parsedData = JsonConvert.DeserializeObject<Root>(resp) ?? throw new Exception($"反序列化失败: {resp}");

            // 判断是否出错
            if (parsedData.error_code != 0) return OcrResult.Fail(parsedData.error_msg);

            // 提取content的值
            var ocrResult = new OcrResult();
            foreach (var item in parsedData.words_result)
            {
                var content = new OcrContent(item.words);
                Converter(item.location).ForEach(pg => content.BoxPoints.Add(new BoxPoint(pg.X, pg.Y)));
                ocrResult.OcrContents.Add(content);
            }
            return ocrResult;
        }

        public IOCR Clone()
        {
            return new BaiduOCR
            {
                Identify = this.Identify,
                Type = this.Type,
                IsEnabled = this.IsEnabled,
                Icon = this.Icon,
                Name = this.Name,
                Url = this.Url,
                AppID = this.AppID,
                AppKey = this.AppKey,
                Icons = this.Icons,
            };
        }

        #endregion Interface Implementation

        #region Baidu Offcial Support

        public List<BoxPoint> Converter(Location location) =>
        [
            //left top
            new(location.left, location.top),

            //right top
            new(location.left + location.width, location.top),

            //right bottom
            new(location.left + location.width, location.top + location.height),

            //left bottom
            new(location.left, location.top + location.height)
        ];

        public class Location
        {
            /// <summary>
            ///
            /// </summary>
            public int top { get; set; }

            /// <summary>
            ///
            /// </summary>
            public int left { get; set; }

            /// <summary>
            ///
            /// </summary>
            public int width { get; set; }

            /// <summary>
            ///
            /// </summary>
            public int height { get; set; }
        }

        public class Words_resultItem
        {
            /// <summary>
            ///
            /// </summary>
            public string words { get; set; } = string.Empty;

            /// <summary>
            ///
            /// </summary>
            public Location location { get; set; } = new();
        }

        public class Root
        {
            /// <summary>
            ///
            /// </summary>
            public List<Words_resultItem> words_result { get; set; } = [];

            /// <summary>
            ///
            /// </summary>
            public int words_result_num { get; set; }

            /// <summary>
            ///
            /// </summary>
            public string log_id { get; set; } = string.Empty;

            /// <summary>
            /// 
            /// </summary>
            public string error_msg { get; set; } = string.Empty;

            /// <summary>
            /// 
            /// </summary>
            public int error_code { get; set; }
        }

        /**
        * 使用 AK，SK 生成鉴权签名（Access Token）
        * @return 鉴权签名信息（Access Token）
        */

        public async Task<string> GetAccessTokenAsync(string API_KEY, string SECRET_KEY, CancellationToken token)
        {
            var url = "https://aip.baidubce.com/oauth/2.0/token";
            var param = new Dictionary<string, string[]>
            {
                {"grant_type", ["client_credentials"] },
                {"client_id", [API_KEY] },
                {"client_secret", [SECRET_KEY] }
            };
            var resp = await HttpUtil.PostAsync(url, null, param, token);
            var access_token = JsonConvert.DeserializeObject<JObject>(resp)?["access_token"]?.ToString() ?? "";
            return access_token;
        }

        #endregion Baidu Offcial Support
    }
}