namespace BookLibraryManager.DomainModels;

public class Publisher
{
    private readonly List<Book> _books = [];
    private readonly List<Author> _authors = [];
    private Publisher()
    {
        PublisherId = Guid.NewGuid();
        BooksPublished = _books.AsReadOnly();
        BookAuthors = _authors.AsReadOnly();
    }

    public Publisher(string publisherName, string publisherAddress)
    {
        PublisherId = Guid.NewGuid();
        PublisherName = publisherName;
        PublisherAddress = publisherAddress;
        BooksPublished = _books.AsReadOnly();
        BookAuthors = _authors.AsReadOnly();
    }
    public Guid PublisherId { get; init; }

    public string PublisherName { get; init; }

    public string PublisherAddress { get; init; }

    public IEnumerable<Book> BooksPublished { get; }

    public IEnumerable<Author> BookAuthors { get; }
    
    public void AddBook(Book book)
    {
        _books.Add(book);
    }
    
    public void AddAuthor(Author author)
    {
        _authors.Add(author);
    }
}