﻿using Richasy.Controls.Reader.Enums;
using Richasy.Controls.Reader.Models;
using Richasy.Controls.Reader.Models.Epub;
using Richasy.Controls.Reader.Views;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;

namespace Richasy.Controls.Reader
{
    public partial class ReaderPanel
    {
        private ContentPresenter _mainPresenter;
        private TxtView _txtView;
        private EpubView _epubView;
        /// <summary>
        /// 读取Txt文件时的全部文本缓存
        /// </summary>
        private string _txtContent;
        /// <summary>
        /// 解析的Epub书籍
        /// </summary>
        private EpubBook _epubContent;
        /// <summary>
        /// 解析Txt文件进行分章时最大解析行数
        /// </summary>
        private static int MAX_TXT_PARSE_LINES = 200;
        /// <summary>
        /// 章节字符数限制
        /// </summary>
        private static int MAX_CHAPTER_LENGTH = 50;

        private bool _isLoading = false;

        private int _tempEpubChapterIndex = 0;

        /// <summary>
        /// 章节划分正则表达式
        /// </summary>
        public Regex ChapterDivisionRegex { get; set; }

        /// <summary>
        /// 目录列表
        /// </summary>
        public List<Chapter> Chapters { get; internal set; }
        /// <summary>
        /// 当前在读章节
        /// </summary>
        public Chapter CurrentChapter { get; internal set; }
        /// <summary>
        /// 阅读器类型
        /// </summary>
        public ReaderType ReaderType { get; private set; }

        public string[] ChapterEndKey { get; set; }
        public string[] ChapterExtraKey { get; set; }

        /// <summary>
        /// 选中文本
        /// </summary>
        public string SelectedText
        {
            get
            {
                if (_mainPresenter.Content != null)
                    return (_mainPresenter.Content as ReaderViewBase).SelectedText;
                else
                    return "";
            }
        }
    }
}
