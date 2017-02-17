using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace UWPSettings.Managers
{
    public enum Devices
    {
        Phone,
        Tablet,
        Desktop,
        Xbox,
        IoT,
        Continuum,
        SurfaceHub
    }
    public class DeviceManager
    {
        #region Get Mobile Mode
        private static Devices GetMobileMode()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1))
            {
                var keyboard = new Windows.Devices.Input.KeyboardCapabilities();
                if (keyboard.KeyboardPresent > 0)
                {
                    return Devices.Continuum;
                }
                else
                {
                    return Devices.Phone;
                }
            }
            else
            {
                return Devices.Tablet;
            }
        }
        #endregion

        #region Get Desktop Mode
        private static Devices GetDesktopMode()
        {
            var settings = UIViewSettings.GetForCurrentView();

            return settings.UserInteractionMode == UserInteractionMode.Mouse
                       ? Devices.Desktop : Devices.Tablet;
        }
        #endregion

        #region Interop
        public static Devices GetCurrentDevice()
        {
            switch (AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Mobile":
                    return GetMobileMode();
                case "Windows.Desktop":
                    return GetDesktopMode();
                case "Windows.Universal":
                    return Devices.IoT;
                case "Windows.Team":
                    return Devices.SurfaceHub;
                case "Windows.Xbox":
                    return Devices.Xbox;
                default:
                    return Devices.Desktop;
            }
        }

        public static bool CurrentIs(params Devices[] devices)
        {
            if (devices == null)
                return false;

            var currentdevice = GetCurrentDevice();

            return devices.Contains(currentdevice);
        }
        #endregion
    }
}
