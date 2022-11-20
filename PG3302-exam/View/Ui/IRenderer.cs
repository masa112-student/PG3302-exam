using Domain.Core;
using Domain.Data;

namespace View.Ui
{
    /// <summary>
    /// The interface for all things rendering based.
    /// 
    /// CursorVisible is intended to be used when accepting user input in order to show them where/what they're typing
    /// WindowDimension is the size of the window
    /// 
    /// ClearScreent will remove everything that has been drawn.
    /// DrawString and DrawString should draw their respective entity to the screen assuming the x and y are within the WindowDimension
    /// </summary>
    public interface IRenderer
    {
        bool CursorVisible { get; set; }
        Dimension WindowDimension { get; }

        void ClearScreen();
        void DrawString(int x, int y, string s);
        void DrawSprite(Sprite sprite);
    }
}
