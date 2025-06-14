namespace Task1;

public class HtmlEncodedMessage : MessageDecorator
{
    public HtmlEncodedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        var content = base.GetContent();
        return System.Net.WebUtility.HtmlEncode(content);
    }
}