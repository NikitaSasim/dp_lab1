namespace Task1;

public class TextMessage : IMessage
{
    private string _text;

    public TextMessage(string text)
    {
        _text = text;
    }

    public string GetContent()
    {
        return _text;
    }
}