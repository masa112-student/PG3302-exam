using System.Text;

/// <summary>
/// A helper class for reading input from the user one char at a time.
/// It will only add letters, digits and space to the string, and supports backspace for deleting chars.
/// GetInputString acts as an extension point for subclasses should additional processing of the string be required.
/// </summary>
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

    public virtual string GetInputString() {
        return _input.ToString();
    }
}