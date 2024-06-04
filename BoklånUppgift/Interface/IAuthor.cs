using BoklånUppgift.Model;

namespace BoklånUppgift.Interface
{
    public interface IAuthor
    {
        public Task<Author> GetByIdAsync(int id);
        public Task<List<Author>> GetAllAsync();
        public Task AddAsync(Author author);
    }
}
