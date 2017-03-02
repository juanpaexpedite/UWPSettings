using Examples.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSettings.Common;
using UWPSettings.Managers;
using Windows.UI.Popups;

namespace Examples.Jobs
{
    public class ExampleJobs
    {
        public static async Task LaunchExampleOne()
        {
            var title = "Example One Settings";
            await WindowManager.ShowSettingsDialog(title, SampleListOne());
        }

        public static async Task LaunchExampleTwo()
        {
            var title = "Menu";
            await WindowManager.ShowSettingsDialog(title, SampleListTwo());
        }

        public static async Task LaunchExampleThree()
        {
            var title = "Menu";
            await WindowManager.ShowSettingsDialog(title, SampleListTwo(),0);
        }

        public static List<Setting> SampleListOne()
        {
            var type = typeof(ChildElement);
            var font = "Segoe MDL2 Assets";
            var specialfont = "ms-appx:///Assets/Fonts/SetMDL2.ttf#Settings MDL2 Assets";

            var system = new Setting("\uE770", font, "System", "Display, notifications, power", type);
            var devices = new Setting("\uE772", font, "Devices", "Bluetooth, printers, mouse", type);
            var network = new Setting("\uE774", font, "Network & Internet", "Wi-Fi, airplane mode, VPN", type);
            var personalization = new Setting("\uE771", font, "Personalization", "Background, lock screen, colors", type);
            var apps = new Setting("\uE71D", font, "Apps", "Uninstall, defaults, optional features", type);
            var accounts = new Setting("\uE77B", font, "Accounts", "Your accounts, email, sync, work, family", type);
            var time = new Setting("\uE775", font, "Time & language", "Speech, region, date", type);
            var gaming = new Setting("\uEB70", specialfont, "Gaming", "Game bar, DVR, broadcasting, Game Mode", type);
            var ease = new Setting("\uE776", font, "Ease of Access", "Narrator, magnifier, high constrast", type);
            var privacy = new Setting("\uE72E", font, "Privacy", "Location, camera", type);
            var update = new Setting("\uE895", font, "Update & security", "Windows Update, recovery, backup", type);

            return new List<Setting> { system, devices, network, personalization, apps, accounts, time, gaming, ease, privacy, update };
        }

        public static List<Setting> SampleListTwo()
        {
            var type = typeof(ChildElement);

            var font = "Segoe MDL2 Assets";
            var hubfont = "ms-appx:///Assets/Fonts/FHubMDL2.ttf#Feedback Hub MDL2 Assets";

            var markdown = new Uri("ms-appx:///Assets/Data/Example.md");

            var announcements = new Setting("\uE789", font, "Announcements", "Release notes", markdown);
            var personalization = new Setting("\uE771", font, "Personalization", "Font size, theme", type);
            var quests = new Setting("\uED40", hubfont, "Quests", "Discover all the features", type);
            var rate = new Setting("\uE735", font, "Rate", "Your opinion is important to improve the app.", new Uri("ms-windows-store://review/?ProductId=9p3g1v8tp0bq"));
            var more = new Setting("\uE71D", font, "More Apps", "Our apps in the store", new Uri("ms-windows-store://publisher/?name=Mareinsula"));
            var feedback = new Setting("\uE939", font, "Feedback", "Features you want and issues you have", ShowMessage);
            var pin = new Setting("\uE718", font, "Pin", "Pin to start", ShowMessage);
            var help = new Setting("\uE897", font, "Help", "documentation of your interest", markdown);
            var ads = new Setting("\uED54", hubfont, "Remove ads", "Donate really helps!", ShowMessage);
            var shortcuts = new Setting("\uE765", font, "Shortcuts", "Keyboard shortcuts", markdown);
            var about = new Setting("\uE7C1", font, "About", "What do we do", markdown);
            var privacy = new Setting("\uEB4E", font, "Privacy policy", "Link to the information", new Uri("http://microsoft.com"));

            return new List<Setting> { announcements, personalization, quests, rate, more, feedback, pin, ads, help, shortcuts, about, privacy };
        }

        private static async void ShowMessage(Setting setting)
        {
            string message = setting.Description;
            if (setting.Title == "Pin")
            {
                message = "more information: https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/tiles-badges-notifications";
            }
            else if (setting.Title == "Feedback")
            {
                message = "more information: https://docs.microsoft.com/en-us/windows/uwp/monetize/launch-feedback-hub-from-your-app";
            }
            var showdialog = new MessageDialog(message, setting.Title);
            await showdialog.ShowAsync();
        }

        /// <summary>
        /// You can visually search the colors from the App: UWP Technical Guide -> Colors -> Accent
        /// </summary>
        /// <returns></returns>
        public static List<Badge> SampleBadges()
        {
            var badge0 = new Badge("Feedback fledgling", "Submit 50 posts", Badge.StarNumbers.None, true, DateTime.Now, ThemeColors.Orange16, "\uED15");

            var badge1 = new Badge("Feedback fledgling", "Submit 50 posts", Badge.StarNumbers.One, true, DateTime.Now, ThemeColors.Orange16, "\uED15");
            var badge2 = new Badge("So it begins", "Submit 50 posts", Badge.StarNumbers.One, true, DateTime.Now, ThemeColors.Cyan151, "\uE7C1");
            var badge3 = new Badge("Ninja cat", "Submit 50 posts", Badge.StarNumbers.None, true, DateTime.Now, ThemeColors.Cobalt207, "🐱‍💻", "Segoe UI Emoji");

            var badge4 = new Badge("Feedback fanatic", "Submit 50 posts", Badge.StarNumbers.Two, true, DateTime.Now, ThemeColors.Orange16, "\uED15");
            var badge5 = new Badge("The journey continues", "Submit 50 posts", Badge.StarNumbers.Two, true, DateTime.Now, ThemeColors.Cyan151, "\uE7C1");
            var badge6 = new Badge("Business cat", "Submit 50 posts", Badge.StarNumbers.None, true, DateTime.Now, ThemeColors.Cobalt207, "🐱‍👓", "Segoe UI Emoji");


            var badge7 = new Badge("Feedback phenom", "Submit 50 posts", Badge.StarNumbers.Three, false, DateTime.Now, ThemeColors.Orange16, "\uED15");
            var badge8 = new Badge("Epic quest", "Submit 50 posts", Badge.StarNumbers.Three, false, DateTime.Now, ThemeColors.Cyan151, "\uE7C1");
            var badge9 = new Badge("Astrocat", "Submit 50 posts", Badge.StarNumbers.None, false, DateTime.Now, ThemeColors.Cobalt207,  "🐱‍🚀", "Segoe UI Emoji");

            var badges = new List<Badge> { badge0, badge1, badge2, badge3, badge4, badge5, badge6, badge7, badge8, badge9 };

            return badges;
        }

    }
}
