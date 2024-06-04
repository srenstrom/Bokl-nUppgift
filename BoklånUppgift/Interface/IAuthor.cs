using BoklånUppgift.Model;

namespace BoklånUppgift.Interface
{
    public interface IAuthor
    {
        public Task GetByIdAsync(int id);
        public Task<Author> GetAllAsync(Author author);
        public Task<Author> AddAsync(Author author);
    }
}
