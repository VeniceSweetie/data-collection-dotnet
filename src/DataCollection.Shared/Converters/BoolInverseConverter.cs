﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
#if __UWP__
using Windows.UI.Xaml.Data;
using Culture = System.String;
#else
using System.Windows.Data;
using Culture = System.Globalization.CultureInfo;
#endif

namespace Esri.ArcGISRuntime.OpenSourceApps.DataCollection.Shared.Converters
{
    public class BoolInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, Culture language)
        {
            if (value is bool boolvalue)
            {
                return !boolvalue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, Culture language)
        {
            if (value is bool boolvalue)
            {
                return !boolvalue;
            }
            return value;
        }
    }
}