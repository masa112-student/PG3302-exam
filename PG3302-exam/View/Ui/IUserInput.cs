namespace View.Ui
{
    /// <summary>
    /// Interface for receiving data from the user
    /// 
    /// IsKeyDown should be a non-blocking way to check if a key is being pressed.
    /// ReadInput should wait for the user to press a key, and the retur the char val.
    /// 
    /// 
    /// </summary>
    public interface IUserInput
    {
        bool IsKeyDown(ConsoleKey key);
        char ReadInput();
    }
}
