using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Drawing;
namespace Pacman
{
    static public class LoadFont //this class loads in the custom pacman font
    {
        static public Font loadFont(int size)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"Resources\pacmanfont.ttf");
            return new Font(pfc.Families[0], size, FontStyle.Regular);
        }
    }
}
