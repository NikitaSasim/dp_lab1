namespace Task3;

public class Book : IBook
{
    private string _content;

    public Book()
    {
        Console.WriteLine("Loading book from database...");
        Thread.Sleep(2000);
        _content = "This is the full content of the book.";
    }

    public string ReadContent()
    {
        return _content;
    }
}