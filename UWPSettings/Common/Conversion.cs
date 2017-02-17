using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSettings.Managers;
using Windows.UI.Xaml;

namespace UWPSettings.Common
{
    public class Conversion
    {
        public static Thickness ToThickness(bool value)
        {
            return new Thickness(value ? 1 : 0);
        }

        public static Thickness ToDesktopThickness(double value)
        {
            var device = DeviceManager.GetCurrentDevice();
            return device == Devices.Phone ? new Thickness(0) : new Thickness(value);
        }

        public static Visibility ToVisible(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }

        public static Visibility ToInvertVisible(bool value)
        {
            return value ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
