using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSettings.Common
{
    public class Badge
    {
        public Badge(string title, string description, StarNumbers stars, bool earned, DateTime earneddatetime, string hexcolor, string icon, string iconfontfamily = "Segoe MDL2 Assets")
        {
            Title = title;
            Description = description;
            Stars = stars;
            Earned = earned;
            EarnedDateTime = earneddatetime;
            HexColor = hexcolor;
            Icon = icon;
            IconFontFamily = iconfontfamily;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public StarNumbers Stars { get; set; }
        public bool Earned { get; set; }
        public DateTime EarnedDateTime { get; set; }
        public String HexColor { get; set; }
        public String Icon { get; set; }
        public String IconFontFamily { get; set; }

        public enum StarNumbers
        {
            None, One, Two, Three
        }
    }
}
