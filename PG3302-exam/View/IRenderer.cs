using Domain.Core;
using Domain.Data;

namespace View
{
    public interface IRenderer
    {
        bool CursorVisible { get; set; }
        Dimension WindowDimension { get; }

        void ClearScreen();
        void DrawString(int x, int y, string s);
        void DrawSprite(Sprite sprite);
    }
}
