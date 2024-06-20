﻿using System.ComponentModel;
using System.Linq;

namespace STranslate.Model;

public class ConfigModel
{
    /// <summary>
    /// 开机自启动
    /// </summary>
    public bool IsStartup { get; set; }

    /// <summary>
    /// 是否管理员启动
    /// </summary>
    public bool NeedAdministrator { get; set; }

    /// <summary>
    /// 历史记录大小
    /// </summary>
    public long HistorySize { get; set; }

    /// <summary>
    /// 自动识别语种标度
    /// </summary>
    public double AutoScale { get; set; }

    /// <summary>
    /// 是否亮色模式
    /// </summary>
    public ThemeType ThemeType { get; set; }

    /// <summary>
    /// 是否跟随鼠标
    /// </summary>
    public bool IsFollowMouse { get; set; }

    /// <summary>
    /// OCR结果翻译关闭OCR界面
    /// </summary>
    public bool CloseUIOcrRetTranslate { get; set; }

    /// <summary>
    /// 截图出现问题尝试一下
    /// </summary>
    public bool UnconventionalScreen { get; set; }

    /// <summary>
    /// OCR时是否自动复制文本
    /// </summary>
    public bool IsOcrAutoCopyText { get; set; }

    /// <summary>
    /// 是否调整完语句后翻译
    /// </summary>
    public bool IsAdjustContentTranslate { get; set; }

    /// <summary>
    /// 取词时移除换行
    /// </summary>
    public bool IsRemoveLineBreakGettingWords { get; set; }

    /// <summary>
    /// OCR取词时移除换行
    /// </summary>
    public bool IsRemoveLineBreakGettingWordsOCR { get; set; }

    /// <summary>
    /// 鼠标双击托盘程序功能
    /// </summary>
    public DoubleTapFuncEnum DoubleTapTrayFunc { get; set; } = DoubleTapFuncEnum.InputFunc;

    /// <summary>
    /// 原始语言
    /// </summary>
    public LangEnum SourceLang { get; set; } = LangEnum.auto;

    /// <summary>
    /// 目标语言
    /// </summary>
    public LangEnum TargetLang { get; set; } = LangEnum.auto;

    /// <summary>
    /// 退出时的位置
    /// </summary>
    public string Position { get; set; } = string.Empty;

    /// <summary>
    /// 自定义字体
    /// </summary>
    public string CustomFont { get; set; } = ConstStr.DEFAULTFONTNAME;

    /// <summary>
    /// 鼠标划词取消后是否保留置顶
    /// </summary>
    public bool IsKeepTopmostAfterMousehook { get; set; } = false;

    /// <summary>
    /// 是否显示设置图标
    /// </summary>
    public bool IsShowPreference { get; set; } = true;

    /// <summary>
    /// 是否显示配置服务图标
    /// </summary>
    public bool IsShowConfigureService { get; set; } = false;

    /// <summary>
    /// 是否显示打开鼠标划词图标
    /// </summary>
    public bool IsShowMousehook { get; set; } = false;

    /// <summary>
    /// 是否显示打开增量翻译图标
    /// </summary>
    public bool IsShowIncrementalTranslation { get; set; } = false;

    /// <summary>
    /// 是否显示截图翻译图标
    /// </summary>
    public bool IsShowScreenshot { get; set; } = false;

    /// <summary>
    /// 是否显示OCR图标
    /// </summary>
    public bool IsShowOCR { get; set; } = false;

    /// <summary>
    /// 是否显示静默OCR图标
    /// </summary>
    public bool IsShowSilentOCR { get; set; } = false;

    /// <summary>
    /// 是否显示监听剪贴板
    /// </summary>
    public bool IsShowClipboardMonitor { get; set; } = false;

    /// <summary>
    /// 是否显示识别二维码图标
    /// </summary>
    public bool IsShowQRCode { get; set; } = false;

    /// <summary>
    /// 是否显示历史记录图标
    /// </summary>
    public bool IsShowHistory { get; set; } = false;

    /// <summary>
    /// 取词间隔
    /// </summary>
    /// <remarks>
    /// 默认200，体验区别不大，主要是避免了福昕阅读器，复制时弹窗导致取词时间变长最终无法取词成功
    /// https://github.com/zggsong/stranslate/issues/13
    /// </remarks>
    public int WordPickingInterval { get; set; } = 200;

    /// <summary>
    /// 启动时隐藏主界面
    /// </summary>
    public bool IsHideOnStart { get; set; } = false;

    /// <summary>
    /// 收缩框是否显示复制按钮
    /// </summary>
    public bool ShowCopyOnHeader { get; set; } = false;

    /// <summary>
    /// 激活窗口时光标移动至末尾
    /// </summary>
    public bool IsCaretLast { get; set; } = false;

    /// <summary>
    /// 网络代理方式
    /// </summary>
    public ProxyMethodEnum ProxyMethod { get; set; } = ProxyMethodEnum.系统代理;

    /// <summary>
    /// 代理IP
    /// </summary>
    public string ProxyIp { get; set; } = string.Empty;

    /// <summary>
    /// 代理端口
    /// </summary>
    public int? ProxyPort { get; set; }

    /// <summary>
    /// 代理是否需要验证
    /// </summary>
    public bool IsProxyAuthentication { get; set; }

    /// <summary>
    /// 代理用户名
    /// </summary>
    public string ProxyUsername { get; set; } = string.Empty;

    /// <summary>
    /// 代理密码
    /// </summary>
    public string ProxyPassword { get; set; } = string.Empty;

    /// <summary>
    /// 翻译后自动复制结果
    /// </summary>
    public int CopyResultAfterTranslateIndex { get; set; } = 0;

    /// <summary>
    /// 是否增量翻译
    /// </summary>
    public bool IncrementalTranslation { get; set; } = false;

    /// <summary>
    /// 是否开启重复触发显示界面为显示/隐藏
    /// </summary>
    public bool IsTriggerShowHide { get; set; } = false;

    /// <summary>
    /// 是否显示主窗口提示词
    /// </summary>
    public bool IsShowMainPlaceholder { get; set; } = true;

    /// <summary>
    /// 截图是否显示辅助线
    /// </summary>
    public bool ShowAuxiliaryLine { get; set; } = true;

    /// <summary>
    /// WebDav Type
    /// </summary>
    public BackupType BackupType { get; set; } = BackupType.Local;

    /// <summary>
    /// WebDavUrl
    /// </summary>
    public string WebDavUrl { get; set; } = string.Empty;

    /// <summary>
    /// WebDav用户名
    /// </summary>
    public string WebDavUsername { get; set; } = string.Empty;

    /// <summary>
    /// WebDav密码
    /// </summary>
    public string WebDavPassword { get; set; } = string.Empty;

    /// <summary>
    /// 切换语言时自动翻译
    /// </summary>
    public bool ChangedLang2Execute { get; set; } = false;

    /// <summary>
    /// Ocr切换语言时自动翻译
    /// </summary>
    public bool OcrChangedLang2Execute { get; set; } = false;

    /// <summary>
    /// 如果出现OpenClipboard失败(0x800401D0(CLIPBRD E CANT OPEN))尝试解决
    /// https://stackoverflow.com/questions/68666/clipbrd-e-cant-open-error-when-setting-the-clipboard-from-net
    /// </summary>
    public bool UseFormsCopy { get; set; } = false;

    /// <summary>
    /// 外部调用端口
    /// </summary>
    public int? ExternalCallPort { get; set; }

    /// <summary>
    /// OCR页面高度
    /// </summary>
    public double? OcrViewHeight { get; set; }

    /// <summary>
    /// OCR页面宽度
    /// </summary>
    public double? OcrViewWidth { get; set; }

    /// <summary>
    /// 语种识别服务
    /// </summary>
    public LangDetectType DetectType { get; set; } = LangDetectType.Local;

    /// <summary>
    /// 禁用热键
    /// </summary>
    public bool DisableGlobalHotkeys { get; set; } = false;

    /// <summary>
    /// 主界面最大高度
    /// </summary>
    public double MainViewMaxHeight { get; set; } = 840;

    /// <summary>
    /// 主界面宽度
    /// </summary>
    public double MainViewWidth { get; set; } = 460;

    /// <summary>
    /// 热键
    /// </summary>
    public Hotkeys? Hotkeys { get; set; }

    /// <summary>
    /// 服务
    /// </summary>
    public BindingList<ITranslator>? Services { get; set; }

    /// <summary>
    /// OCR
    /// </summary>
    public OCRCollection<IOCR>? OCRList { get; set; }

    /// <summary>
    /// TTS
    /// </summary>
    public TTSCollection<ITTS>? TTSList { get; set; }

    /// <summary>
    /// Copy
    /// </summary>
    /// <returns></returns>
    public ConfigModel Clone()
    {
        return new ConfigModel
        {
            IsStartup = IsStartup,
            NeedAdministrator = NeedAdministrator,
            HistorySize = HistorySize,
            AutoScale = AutoScale,
            ThemeType = ThemeType,
            IsFollowMouse = IsFollowMouse,
            CloseUIOcrRetTranslate = CloseUIOcrRetTranslate,
            UnconventionalScreen = UnconventionalScreen,
            IsOcrAutoCopyText = IsOcrAutoCopyText,
            IsAdjustContentTranslate = IsAdjustContentTranslate,
            IsRemoveLineBreakGettingWords = IsRemoveLineBreakGettingWords,
            IsRemoveLineBreakGettingWordsOCR = IsRemoveLineBreakGettingWordsOCR,
            DoubleTapTrayFunc = DoubleTapTrayFunc,
            SourceLang = SourceLang,
            TargetLang = TargetLang,
            Position = Position,
            CustomFont = CustomFont,
            IsKeepTopmostAfterMousehook = IsKeepTopmostAfterMousehook,
            IsShowPreference = IsShowPreference,
            IsShowConfigureService = IsShowConfigureService,
            IsShowMousehook = IsShowMousehook,
            IsShowIncrementalTranslation = IsShowIncrementalTranslation,
            IsShowScreenshot = IsShowScreenshot,
            IsShowOCR = IsShowOCR,
            IsShowSilentOCR = IsShowSilentOCR,
            IsShowClipboardMonitor = IsShowClipboardMonitor,
            IsShowQRCode = IsShowQRCode,
            IsShowHistory = IsShowHistory,
            WordPickingInterval = WordPickingInterval,
            IsHideOnStart = IsHideOnStart,
            ShowCopyOnHeader = ShowCopyOnHeader,
            IsCaretLast = IsCaretLast,
            ProxyMethod = ProxyMethod,
            ProxyIp = ProxyIp,
            ProxyPort = ProxyPort,
            IsProxyAuthentication = IsProxyAuthentication,
            ProxyUsername = ProxyUsername,
            ProxyPassword = ProxyPassword,
            CopyResultAfterTranslateIndex = CopyResultAfterTranslateIndex,
            IncrementalTranslation = IncrementalTranslation,
            IsTriggerShowHide = IsTriggerShowHide,
            IsShowMainPlaceholder = IsShowMainPlaceholder,
            ShowAuxiliaryLine = ShowAuxiliaryLine,
            BackupType = BackupType,
            WebDavUrl = WebDavUrl,
            WebDavUsername = WebDavUsername,
            WebDavPassword = WebDavPassword,
            ChangedLang2Execute = ChangedLang2Execute,
            OcrChangedLang2Execute = OcrChangedLang2Execute,
            UseFormsCopy = UseFormsCopy,
            ExternalCallPort = ExternalCallPort,
            OcrViewHeight = OcrViewHeight,
            OcrViewWidth = OcrViewWidth,
            DetectType = DetectType,
            DisableGlobalHotkeys = DisableGlobalHotkeys,
            MainViewMaxHeight = MainViewMaxHeight,
            MainViewWidth = MainViewWidth,
            Hotkeys = Hotkeys?.Clone(),
            Services = Services?.Clone(),
            OCRList = OCRList?.DeepCopy(),
            TTSList = TTSList?.DeepCopy()
        };
    }
}

internal static class Extensions
{
    public static BindingList<T> Clone<T>(this BindingList<T> listToClone)
        where T : ITranslator
    {
        return new BindingList<T>(listToClone.Select(item => (T)item.Clone()).ToList());
    }
}
