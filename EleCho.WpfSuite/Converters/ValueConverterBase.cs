﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EleCho.WpfSuite
{
    public abstract class ValueConverterBase<T> : DependencyObject, IValueConverter
        where T : ValueConverterBase<T>
    {
        public abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

        public virtual object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
