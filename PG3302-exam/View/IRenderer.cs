using Domain.Core;

namespace View
{
    public interface IRenderer
    {
        bool CursorVisible { get; set; }
        void ClearScreen();
        void DrawString(int x, int y, string s);
        void DrawSprite(Sprite sprite);
    }
}
