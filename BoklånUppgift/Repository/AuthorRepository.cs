using BoklånUppgift.Data;
using BoklånUppgift.Interface;
using BoklånUppgift.Model;
using Microsoft.EntityFrameworkCore;

namespace BoklånUppgift.Repository
{
    public class AuthorRepository : IAuthor
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(Author author)
        {
            await applicationDbContext.AddAsync(author);
            
            applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await applicationDbContext.Authors
                .Include(b => b.Books)
                .ToListAsync();
        }

      

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await applicationDbContext.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(s => s.AuthorId == id);
            return author;

        }
    }
}
