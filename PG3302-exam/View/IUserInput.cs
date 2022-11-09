namespace View
{
    public interface IUserInput
    {
        bool IsKeyDown(ConsoleKey key);
        char ReadInput();
    }
}
