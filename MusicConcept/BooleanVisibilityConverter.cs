﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MusicConcept
{
    /// <summary>
    /// Konvertiert Boolean zu Visibility
    /// </summary>
    public class BooleanVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public BooleanVisibilityConverter()
        {
            this.IsInverted = false;
        }
        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolean = (bool)value;
            if (this.IsInverted)
                boolean = !boolean;

            if (boolean)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (this.IsInverted)
                if ((Visibility)value == Visibility.Visible)
                    return true;
                else 
                    return false;
            else
                if ((Visibility)value == Visibility.Visible)
                    return false;
                else 
                    return true;
        }
    }
}
