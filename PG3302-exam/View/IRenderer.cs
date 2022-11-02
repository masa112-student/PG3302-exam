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
        void DrawChar(int x, int y, char c);
        void DrawSprite(Sprite sprite);
    }
}
