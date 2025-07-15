namespace LibraryManagement.BlazorServer.Models
{
    /// <summary>
    /// Represents a book in the library system.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unique identifier for the book.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Publication date.
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Genre or category of the book.
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Price of the book.
        /// </summary>
        public decimal Price { get; set; }
    }
}
