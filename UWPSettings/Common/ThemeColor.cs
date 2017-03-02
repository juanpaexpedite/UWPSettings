using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UWPSettings.Common
{

    public static class ThemeColors
    {
        public static String Yellow44 { get { return hexstheme[0]; } }
        public static String Yellow33 { get { return hexstheme[1]; } }
        public static String Orange22 { get { return hexstheme[2]; } }
        public static String Orange21 { get { return hexstheme[3]; } }
        public static String Orange16 { get { return hexstheme[4]; } }
        public static String Red9 { get { return hexstheme[5]; } }
        public static String Red358 { get { return hexstheme[6]; } }
        public static String Red0 { get { return hexstheme[7]; } }
        public static String Red355 { get { return hexstheme[8]; } }
        public static String Red356 { get { return hexstheme[9]; } }
        public static String Red336 { get { return hexstheme[10]; } }
        public static String Red335 { get { return hexstheme[11]; } }
        public static String Crimson323 { get { return hexstheme[12]; } }
        public static String Crimson324 { get { return hexstheme[13]; } }
        public static String Crimson307 { get { return hexstheme[14]; } }
        public static String Crimson308 { get { return hexstheme[15]; } }
        public static String Cobalt207 { get { return hexstheme[16]; } }
        public static String Cobalt206 { get { return hexstheme[17]; } }
        public static String Violet242 { get { return hexstheme[18]; } }
        public static String Violet241 { get { return hexstheme[19]; } }
        public static String Violet265 { get { return hexstheme[20]; } }
        public static String Violet266 { get { return hexstheme[21]; } }
        public static String Magenta292 { get { return hexstheme[22]; } }
        public static String Magenta293 { get { return hexstheme[23]; } }
        public static String Cobalt191 { get { return hexstheme[24]; } }
        public static String Cobalt196 { get { return hexstheme[25]; } }
        public static String Cobalt184 { get { return hexstheme[26]; } }
        public static String Cobalt182 { get { return hexstheme[27]; } }
        public static String Cyan170 { get { return hexstheme[28]; } }
        public static String Cyan152 { get { return hexstheme[29]; } }
        public static String Cyan151 { get { return hexstheme[30]; } }
        public static String Turqoise143 { get { return hexstheme[31]; } }
        public static String Red10 { get { return hexstheme[32]; } }
        public static String Orange24 { get { return hexstheme[33]; } }
        public static String Blue215 { get { return hexstheme[34]; } }
        public static String Blue216 { get { return hexstheme[35]; } }
        public static String Cyan166 { get { return hexstheme[36]; } }
        public static String Cyan165 { get { return hexstheme[37]; } }
        public static String Lime87 { get { return hexstheme[38]; } }
        public static String Turqoise120 { get { return hexstheme[39]; } }
        public static String Red1 { get { return hexstheme[40]; } }
        public static String Yellow30 { get { return hexstheme[41]; } }
        public static String Cobalt194 { get { return hexstheme[42]; } }
        public static String Cobalt200 { get { return hexstheme[43]; } }
        public static String Turqoise121 { get { return hexstheme[44]; } }
        public static String Turqoise130 { get { return hexstheme[45]; } }
        public static String Yellow46 { get { return hexstheme[46]; } }
        public static String Yellow39 { get { return hexstheme[47]; } }


        private static string[] hexstheme = new string[]
        {
          "#FFB900","#FF8C00","#F7630C","#CA5010","#DA3B01","#EF6950","#D13438","#FF4343",
            "#E74856","#E81123","#EA005E","#C30052","#E3008C","#BF0077","#C239B3","#9A0089",
            "#0078D7","#0063B1","#8E8CD8","#6B69D6","#8764B8","#744DA9","#B146C2","#881798",
            "#0099BC","#2D7D9A","#00B7C3","#038387","#00B294","#018547","#00CC6A","#10893E",
            "#7A7574","#5D5A58","#68768A","#515C6B","#567C73","#486860","#498205","#107C10",
            "#767676","#4C4A48","#69797E","#4A5459","#647C64","#525E54","#847545","#7E735F"
        };

        public static Color? HexToColor(string hexcolor)
        {
            try
            {
                string A, R, G, B;
                var rgb = hexcolor.Trim('#', ' ');

                if (rgb.Length == 3) //RGB
                {
                    A = "FF";
                    R = rgb.Substring(0, 1); R = $"{R}{R}";
                    G = rgb.Substring(1, 1); G = $"{G}{G}";
                    B = rgb.Substring(2, 1); B = $"{B}{B}";
                }
                else if (rgb.Length == 6) //RRGGBB
                {
                    A = "FF";
                    R = rgb.Substring(0, 2);
                    G = rgb.Substring(2, 2);
                    B = rgb.Substring(4, 2);
                }
                else if (rgb.Length == 4) //ARGB
                {
                    A = rgb.Substring(0, 1); A = $"{A}{A}";
                    R = rgb.Substring(1, 1); R = $"{R}{R}";
                    G = rgb.Substring(2, 1); G = $"{G}{G}";
                    B = rgb.Substring(3, 1); B = $"{B}{B}";
                }
                else if (rgb.Length == 8) //AARRGGBB
                {
                    A = rgb.Substring(0, 2);
                    R = rgb.Substring(2, 2);
                    G = rgb.Substring(4, 2);
                    B = rgb.Substring(6, 2);
                }
                else
                {
                    return null;
                }

                var iA = Byte.Parse(A, NumberStyles.HexNumber);
                var iR = Byte.Parse(R, NumberStyles.HexNumber);
                var iG = Byte.Parse(G, NumberStyles.HexNumber);
                var iB = Byte.Parse(B, NumberStyles.HexNumber);

                return Color.FromArgb(iA, iR, iG, iB);
            }
            catch
            {
                return null;
            }
        }
    }

        
    
}
