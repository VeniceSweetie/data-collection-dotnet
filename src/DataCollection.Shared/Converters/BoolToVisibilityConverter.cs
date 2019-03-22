﻿/*******************************************************************************
  * Copyright 2019 Esri
  *
  *  Licensed under the Apache License, Version 2.0 (the "License");
  *  you may not use this file except in compliance with the License.
  *  You may obtain a copy of the License at
  *
  *  http://www.apache.org/licenses/LICENSE-2.0
  *
  *   Unless required by applicable law or agreed to in writing, software
  *   distributed under the License is distributed on an "AS IS" BASIS,
  *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  *   See the License for the specific language governing permissions and
  *   limitations under the License.
******************************************************************************/

using System;
using System.Globalization;
#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using CustomCultureInfo = System.String;
#else
using System.Windows.Data;
using System.Windows;
using CustomCultureInfo = System.Globalization.CultureInfo;
#endif

namespace Esri.ArcGISRuntime.ExampleApps.DataCollection.Shared.Converters
{
    /// <summary>
    /// Converts boolean to visibility
    /// </summary>
    class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Handle the conversion from a boolean value to a visibility value
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CustomCultureInfo culture)
        {
            if (value is bool)
            {
                // Handle bool(true) to visibility and bool(false) (inverse) to visibility
                if (parameter != null && parameter.ToString() == "Inverse")
                {
                    //if value is false, visibility = visible (inverse)
                    return ((bool)value == false) ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                {
                    //if value is false, visibility is collapsed 
                    return ((bool)value == false) ? Visibility.Collapsed : Visibility.Visible;
                }
            }
            else
                return Visibility.Collapsed;
        }

        /// <summary>
        /// Handle the conversion from a visibility value to a boolean value
        /// </summary>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CustomCultureInfo culture)
        {
            if (value is Visibility)
            {
                // Handle visibility to boolean conversion
                if (parameter != null && parameter.ToString() == "Inverse")
                {
                    //if visibility is collapsed return true, otherwise false (inverse)
                    return ((Visibility)value == Visibility.Collapsed);
                }
                else
                {
                    //if visibility is collapsed return false, otherwise true
                    return ((Visibility)value != Visibility.Collapsed);
                }
            }
            else
                return false;
        }
    }
}
