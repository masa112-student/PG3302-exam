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
