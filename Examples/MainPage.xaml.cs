using Examples.Jobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSettings;
using UWPSettings.Common;
using UWPSettings.Managers;
using UWPSettings.Panes;
using UWPSettings.UI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Examples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Settings Panel

        public async void LaunchExampleOne()
        {
            var title = "Example One Settings";
            await WindowManager.ShowSettingsDialog(title, ExampleJobs.SampleListOne());
        }

        private async void LaunchExampleTwo()
        {
            var title = "Menu";
            await WindowManager.ShowSettingsDialog(title, ExampleJobs.SampleListTwo());
        }

        private async void LaunchExampleThree()
        {
            var title = "Menu";
            await WindowManager.ShowSettingsDialog(title, ExampleJobs.SampleListTwo(),1);
        }

        //Crostinis

        private async void LaunchExampleFour()
        {
            await Crostini.ShowNotification("File exported", icon: "\uE008", seconds: 4);
        }

        private void LaunchExampleFive()
        {
            Crostini.OpenNotification("Exporting file", isindeterminate:true);
        }

        private void CloseExampleFive()
        {
            Crostini.CloseNotification();
        }

        private async void LaunchExampleSix()
        {
            var badge = new Badge("Feedback phenom", "Submit 50 posts", Badge.StarNumbers.Three, true, DateTime.Now, ThemeColors.Orange16, "\uED15");

            var element = new BadgeElement
            {
                BadgeSource = badge
            };

            await Crostini.ShowNotification(badge.Description, title:badge.Title, icon: "\uE008", seconds: 4, content: element, defaultwidth:200);
        }

        private async void LaunchExampleSeven()
        {
            var list = ExampleJobs.SampleBadges();
            var achievements = new AchievementsPane();
            achievements.ItemsSource = list;

            await WindowManager.ShowWindowDialog(achievements,"Achievements", "\uE734");
        }
    }
}
