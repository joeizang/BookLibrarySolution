using BookLibraryManager.DataTransferObjects;
using LanguageExt;
using LanguageExt.Common;
using NodaTime;

namespace BookLibraryManager.DomainModels;

public class Book
{
    private readonly List<Rating> _ratings = [];
    private readonly List<Author> _authors = [];
    
    
    private Book(Guid publisherId)
    {
        PublisherId = publisherId;
        Authors = _authors.AsReadOnly();
        Ratings = _ratings.AsReadOnly();
    }
    
    public Book(string title, int numberOfPages, Instant publishedDate, Guid publisherId, string isbn)
    {
        BookId = Guid.NewGuid();
        Title = title;
        NumberOfPages = numberOfPages;
        PublisherId = publisherId;
        Isbn = isbn;
        PublishedDate = ValidatePublishDate(publishedDate)
            .Match(result => result, Instant.MinValue);// Don't save when the date is minvalue
        Authors = _authors.AsReadOnly();
        Ratings = _ratings.AsReadOnly();
    }
    
    public Guid BookId { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public int NumberOfPages { get; set; }

    public string BookBlob { get; set; } = string.Empty;

    public string BookCoverImage { get; set; } = string.Empty;

    public string Isbn { get; set; }

    public void AddBookDetails(BookDetails bookDetail)
    {
        if(!string.IsNullOrWhiteSpace(bookDetail.BookBlob))
        {
            BookBlob = bookDetail.BookBlob;
        }

        if (!string.IsNullOrWhiteSpace(bookDetail.BookCoverImage))
        {
            BookCoverImage = bookDetail.BookCoverImage;
        }
    }
    
    public Instant PublishedDate { get; set; }

    public IEnumerable<AuthorsBooks> AuthorsBooks { get; }
    
    public IEnumerable<Rating> Ratings { get; }

    public Publisher Publisher { get; }
    
    public Guid PublisherId { get; private set; }

    public IEnumerable<Author> Authors { get; }

    private static Option<Instant> ValidatePublishDate(Instant date)
    {
        return date == default || date == Instant.MinValue 
            ? Option<Instant>.None 
            : Option<Instant>.Some(date);
    }
    
    public void AddAuthor(Author author)
    {
            if (Authors.Contains(author))
            {
                return;
            }
            _authors.Add(author);
            author.AddAuthoredBook(this);
    }
    
    public void AddRating(Rating rating)
    {
        if (Ratings.Contains(rating))
        {
            return;
        }
        _ratings.Add(rating);
    }


}