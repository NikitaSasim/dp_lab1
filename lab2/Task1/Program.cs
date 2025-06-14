using Task1;

IMessage message = new TextMessage("Hello <World>!");
Console.WriteLine("Base: " + message.GetContent());

IMessage encrypted = new EncryptedMessage(message);
Console.WriteLine("Encrypted: " + encrypted.GetContent());

IMessage encoded = new HtmlEncodedMessage(message);
Console.WriteLine("HTML Encoded: " + encoded.GetContent());

IMessage combined = new EncryptedMessage(new HtmlEncodedMessage(new TextMessage("Hello <World>!")));
Console.WriteLine("Combined: " + combined.GetContent());