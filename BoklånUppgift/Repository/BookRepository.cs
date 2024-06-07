using BoklånUppgift.Data;
using BoklånUppgift.Interface;
using BoklånUppgift.Model;
using Microsoft.EntityFrameworkCore;

namespace BoklånUppgift.Repository
{
    public class BookRepository : IBook
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public BookRepository()
        {
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await applicationDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .ToListAsync();
         }
        
        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await applicationDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.BookId == id);

            return book;
        }

        public async Task<Book> ReturnBookAsync(int id)
        {
            var book = await applicationDbContext.Books
                .FirstOrDefaultAsync(b => b.BookId == id);
            book.IsRented = false;
            applicationDbContext.SaveChangesAsync();
            return book;
        }
        public async Task<Book> RentBookAsync(int id)
        {
            var book = await applicationDbContext.Books
                .FirstOrDefaultAsync(b => b.BookId == id);
            book.IsRented = true;
            applicationDbContext.SaveChangesAsync();
            return book;
        }

        public async Task AddAsync(Book book)
        {
            var books = await applicationDbContext.Books.AddAsync(book);
            await applicationDbContext.SaveChangesAsync();

            
        }
    }
}
