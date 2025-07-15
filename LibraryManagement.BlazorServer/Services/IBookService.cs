using LibraryManagement.BlazorServer.Models;

namespace LibraryManagement.BlazorServer.Services
{
    /// <summary>
    /// CRUD operations for Book entities.
    /// </summary>
    public interface IBookService
    {
        /// <summary>Returns all books.</summary>
        Task<List<Book>> GetBooksAsync();

        /// <summary>Returns one book by ID, or null.</summary>
        Task<Book?> GetBookByIdAsync(int id);

        /// <summary>Adds a new book.</summary>
        Task AddBookAsync(Book book);

        /// <summary>Updates an existing book.</summary>
        Task UpdateBookAsync(Book book);

        /// <summary>Deletes a book by ID.</summary>
        Task DeleteBookAsync(int id);
    }
}
