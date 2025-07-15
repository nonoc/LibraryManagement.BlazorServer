using LibraryManagement.BlazorServer.Data;
using LibraryManagement.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.BlazorServer.Services
{

    /// <summary>
    /// EF Core implementation of IBookService.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly AppDbContext _db;

        public BookService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _db.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            // Attach & mark modified in case it's detached
            _db.Entry(book).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var entity = await _db.Books.FindAsync(id);
            if (entity != null)
            {
                _db.Books.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
