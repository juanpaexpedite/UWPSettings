using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSettings.Common
{
    public class Setting
    {
        public Setting(string icon, string fontfamily, string title, string description, Type details) : this(icon, fontfamily, title, description)
        {
            Details = details;
        }

        public Setting(string icon, string fontfamily, string title, string description, Uri uri) : this(icon, fontfamily, title, description)
        {
            Uri = uri;
        }

        public Setting(string icon, string fontfamily, string title, string description, Action<Setting> service) : this(icon, fontfamily, title, description)
        {
            Service = service;
        }


        private Setting(string icon, string fontfamily, string title, string description)
        {
            Icon = icon;
            FontFamily = fontfamily;
            Title = title;
            Description = description;
        }

        public string Icon { get; set; }
        public string FontFamily { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Choose Uri to navigate to an review, etc.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Choose Details to navigate to an instance of the details
        /// </summary>
        public Type Details { get; private set; }

        /// <summary>
        /// Choose Service for special cases like pin, feedback, etc.
        /// </summary>
        public Action<Setting> Service { get; private set; }
    }
}
