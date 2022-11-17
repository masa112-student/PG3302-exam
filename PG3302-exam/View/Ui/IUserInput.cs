namespace View.Ui
{
    public interface IUserInput
    {
        bool IsKeyDown(ConsoleKey key);
        char ReadInput();
    }
}
