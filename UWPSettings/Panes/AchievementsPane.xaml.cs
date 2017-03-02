using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSettings.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPSettings.Panes
{
    public sealed partial class AchievementsPane : UserControl
    {
        #region 
        public IEnumerable<Badge> ItemsSource
        {
            get { return (IEnumerable<Badge>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable<Badge>), typeof(AchievementsPane), new PropertyMetadata(null));
        #endregion

        public AchievementsPane()
        {
            this.InitializeComponent();
        }

        private void BadgeItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(sender is Grid grid)
            {
                var flyout = FlyoutBase.GetAttachedFlyout(grid);
                if(flyout!=null)
                {
                    flyout.ShowAt(grid);
                }
            }
        }
    }
}
