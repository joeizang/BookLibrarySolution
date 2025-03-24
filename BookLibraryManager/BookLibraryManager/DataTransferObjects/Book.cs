using NodaTime;

namespace BookLibraryManager.DataTransferObjects;

public record BookDetails(string? BookBlob, string? BookCoverImage);