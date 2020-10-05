﻿using Richasy.Controls.Reader.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Richasy.Controls.Reader.Views
{
    public partial class TxtView
    {

        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(TxtView), new PropertyMetadata(0, new PropertyChangedCallback(Index_Changed)));

        private static void Index_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var index = (int)e.NewValue;
                if (d is TxtView sender)
                {
                    if (!sender.IsCoreSelectedChanged)
                    {
                        sender.GoToIndex(index);
                    }
                    try
                    {
                        double xi = (Math.Abs(index * sender._columns) * 1.0) / sender._txtGrid.Children.Count;
                        int length = Convert.ToInt32(sender._content.Length * xi);
                        sender._startTextIndex = length;
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        Debug.WriteLine(ex.Message);
#endif
                    }
                    if (index < 0) sender.OnPrevPageSelected();
                    else if (index > sender.Count - 1) sender.OnNextPageSelected();
                    sender.OnSelectionChanged();
                }
            }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(TxtView), new PropertyMetadata(0, new PropertyChangedCallback(Count_Changed)));

        private static void Count_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                if (d is TxtView sender)
                {
                    sender.InitTrackerPositions();
                }
            }
        }

        public double SingleColumnMaxWidth
        {
            get { return (double)GetValue(SingleColumnMaxWidthProperty); }
            set { SetValue(SingleColumnMaxWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SingleColumnMaxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SingleColumnMaxWidthProperty =
            DependencyProperty.Register("SingleColumnMaxWidth", typeof(double), typeof(TxtView), new PropertyMetadata(800.0, new PropertyChangedCallback(SingleColumnMaxWidth_Changed)));

        private static void SingleColumnMaxWidth_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as TxtView;
            sender.SizeChangeHandle();
        }

        public TxtViewStyle ViewStyle
        {
            get { return (TxtViewStyle)GetValue(ViewStyleProperty); }
            set { SetValue(ViewStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewStyleProperty =
            DependencyProperty.Register("ViewStyle", typeof(TxtViewStyle), typeof(TxtView), new PropertyMetadata(new TxtViewStyle()));

        public FlyoutBase ReadFlyout
        {
            get { return (FlyoutBase)GetValue(ReadFlyoutProperty); }
            set { SetValue(ReadFlyoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReadFlyout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadFlyoutProperty =
            DependencyProperty.Register("ReadFlyout", typeof(FlyoutBase), typeof(TxtView), new PropertyMetadata(null, new PropertyChangedCallback(ReadFlyout_Changed)));

        private static void ReadFlyout_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is FlyoutBase flyout && e.NewValue != null)
            {
                var sender = d as TxtView;
                if (sender._txtBlock != null)
                    sender._txtBlock.SelectionFlyout = flyout;
            }
        }
    }
}