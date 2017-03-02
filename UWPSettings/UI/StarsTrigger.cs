using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSettings.Common;
using Windows.UI.Xaml;

namespace UWPSettings.UI
{
    public class StarsTrigger : StateTriggerBase
    {
        #region Stars
        public Badge.StarNumbers Stars
        {
            get { return (Badge.StarNumbers)GetValue(StarsProperty); }
            set { SetValue(StarsProperty, value); }
        }

        public static readonly DependencyProperty StarsProperty =
            DependencyProperty.Register(nameof(Stars), typeof(Badge.StarNumbers), typeof(StarsTrigger), new PropertyMetadata(Badge.StarNumbers.None, OnStarsChanged));

        private static void OnStarsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is StarsTrigger trigger)
            {
                if(trigger.Stars != Badge.StarNumbers.None)
                {
                    trigger.SetActive(true);
                }
                else
                {
                    trigger.SetActive(false);
                }
            }
        }
        #endregion

    }
}
