using BoklånUppgift.Interface;
using BoklånUppgift.Model;

namespace BoklånUppgift.Repository
{
    public class AuthorRepository : IAuthor
    {
        public Task<Author> AddAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAllAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
