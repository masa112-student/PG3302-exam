using System.Text;

class UserInputFormatter
{
    private StringBuilder _input = new StringBuilder();

    public char LastReadChar { get; private set; }
    public bool UserHitEnter { get; private set; }  

    public void AddInput(char c) {
        LastReadChar = c;
        
        if (c == (char)ConsoleKey.Backspace && _input.Length > 0)
            _input.Remove(_input.Length - 1, 1);
        else if(char.IsLetterOrDigit(c) || c == ' ')
            _input.Append(c);

        UserHitEnter = (c == (char)ConsoleKey.Enter);
    }

    public string GetInputString() {
        _input.Replace("\r", string.Empty);
        _input.Replace("\n'", string.Empty);
        _input.Replace("\b", string.Empty);

        return _input.ToString();
    }
}