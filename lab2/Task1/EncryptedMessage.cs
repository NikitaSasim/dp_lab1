namespace Task1;

public class EncryptedMessage : MessageDecorator
{
    public EncryptedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        var content = base.GetContent();
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(content));
    }
}