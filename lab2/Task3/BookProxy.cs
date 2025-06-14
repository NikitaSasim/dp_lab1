namespace Task3;

public class BookProxy : IBook
{
    private readonly User _user;
    private Book? _realBook;

    public BookProxy(User user)
    {
        _user = user;
    }

    public string ReadContent()
    {
        if (!_user.IsRegistered)
            return "Access denied: User is not registered.";

        if (!_user.HasAccessToBook)
            return "Access denied: User does not have permission to read the book.";

        if (_realBook == null)
        {
            _realBook = new Book();
        }

        return _realBook.ReadContent();
    }
}