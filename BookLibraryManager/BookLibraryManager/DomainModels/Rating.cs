namespace BookLibraryManager.DomainModels;

public class Rating
{
    private Rating()
    {
        
    }

    public Rating(string bookReview, double ratingScore, Book book)
    {
        RatingId = Guid.NewGuid();
        RatingScore = CalculateBookRating(ratingScore);
        BookReview = bookReview;
        Book = book;
        BookId = book.BookId;
    }
    public Guid RatingId { get; init; }

    public string BookReview { get; init; } = string.Empty;

    public double RatingScore { get; init; }
    
    public Book Book { get; }
    
    public Guid BookId { get; private set; }

    private static double CalculateBookRating(double score)
    {
        if(score > 5)
        {
            throw new ArgumentException("Rating score cannot be greater than 5");
        }
        return 0D;
    }
}