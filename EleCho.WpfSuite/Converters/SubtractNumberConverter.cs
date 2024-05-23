﻿using System;
using System.Globalization;
using System.Windows;

namespace EleCho.WpfSuite
{
    public class SubtractNumberConverter : SingletonValueConverterBase<SubtractNumberConverter>
    {
        public double Other
        {
            get { return (double)GetValue(OtherProperty); }
            set { SetValue(OtherProperty, value); }
        }

        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                double current = System.Convert.ToDouble(value);
                if (parameter is double parameterNumber)
                    current -= parameterNumber;

                var result = current - Other;
                if (typeof(IConvertible).IsAssignableFrom(targetType))
                {
                    return System.Convert.ChangeType(result, targetType);
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public static readonly DependencyProperty OtherProperty =
            DependencyProperty.Register(nameof(Other), typeof(double), typeof(SubtractNumberConverter), new PropertyMetadata(0.0));
    }
}
