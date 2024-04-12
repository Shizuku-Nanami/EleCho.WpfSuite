﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EleCho.WpfSuite
{
    public class Image : Control
    {
        static Image()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Image), new FrameworkPropertyMetadata(typeof(Image)));
        }

        protected virtual Uri? BaseUri { get; set; }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if(Source is { } imageSource)
            {
                var size = new Size(imageSource.Width, imageSource.Height);
                size.Width = Math.Min(size.Width, constraint.Width);
                size.Height = Math.Min(size.Height, constraint.Height);

                return size;
            }

            return base.MeasureOverride(constraint);
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(ImageSource), typeof(Image), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register(nameof(Stretch), typeof(Stretch), typeof(Image), new FrameworkPropertyMetadata(Stretch.None, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Image), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsRender));

    }
}
