﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace STranslate.Model
{
    public class OcrResult
    {
        public List<OcrContent> OcrContents { get; set; } = [];

        /// <summary>
        /// 精简版文本通过换行组合
        /// </summary>
        public string Text => string.Join(Environment.NewLine, OcrContents.Select((OcrContent x) => x.Text).ToArray()).Trim();

        /// <summary>
        /// 重写ToString方法,以空格组合结果
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Join(" ", OcrContents.Select((OcrContent x) => x.Text).ToArray()).Trim();

        public static OcrResult Empty => new();
    }

    public class OcrContent
    {
        public string Text { get; set; } = string.Empty;

        public List<BoxPoint> BoxPoints { get; set; } = [];

        public OcrContent()
        { }

        public OcrContent(string text)
        {
            Text = text;
        }

        public OcrContent(string text, List<BoxPoint> boxPoints)
        {
            Text = text;
            BoxPoints = boxPoints;
        }
    }

    public class BoxPoint(int x, int y)
    {
        public int X { get; set; } = x;

        public int Y { get; set; } = y;
    }
}