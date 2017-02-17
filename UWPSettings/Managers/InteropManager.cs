using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;

namespace UWPSettings.Managers
{
    public class InteropManager
    {
        public static UIElement LaunchDetails(Type type)
        {
            try
            {
                return (UIElement)Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task LaunchUri(Uri uri)
        {
            await Launcher.LaunchUriAsync(uri);
        }

        public static async Task<string> Read(Uri uri)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            var content = await FileIO.ReadTextAsync(file);
            return content;
        }

    }
}
