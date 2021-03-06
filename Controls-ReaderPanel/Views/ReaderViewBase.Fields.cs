﻿using Richasy.Controls.Reader.Models;
using Windows.UI.Composition;
using Windows.UI.Composition.Interactions;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Richasy.Controls.Reader.Views
{
    public partial class ReaderViewBase
    {
        internal RichTextBlock _displayBlock;
        internal Grid _displayContainer;

        internal int _startTextIndex = 0;
        internal string _content;
        internal double _startX = 0;
        internal int _columns = 1;
        internal bool IsCoreSelectedChanged;
        internal bool IsAnimating;
        internal EventWaiter IndexWaiter;
        internal EventDelayer CreateContentDelayer;

        internal bool _isSizeChangeLoaded = false;

        internal double ParentWidth
        {
            get => (VisualTreeHelper.GetParent(_displayContainer) as FrameworkElement).ActualWidth;
        }

        public string SelectedText
        {
            get => _displayBlock.SelectedText;
        }

        Compositor compositor;
        Vector3KeyFrameAnimation OffsetAnimation;
        Visual PanelVisual;
        Visual ReaderViewVisual;

        InteractionTracker _tracker;
        VisualInteractionSource _source;
        ExpressionAnimation OffsetBind;

        PointerEventHandler PointerWheelChangedEventHandler;
        PointerEventHandler PointerPressedEventHandler;
        PointerEventHandler PointerMovedEventHandler;
        PointerEventHandler PointerReleasedEventHandler;
        PointerEventHandler PointerCanceledEventHandler;
        TappedEventHandler TouchTappedEventHandler;
        HoldingEventHandler TouchHoldingEventHandler;
        GestureRecognizer _gestureRecognizer;
    }
}
