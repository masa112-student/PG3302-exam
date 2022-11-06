using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace View
{
    public interface IRenderer
    {
        void ClearScreen();
        void DrawString(int x, int y, string s);
        void DrawSprite(Sprite sprite);
    }
}
