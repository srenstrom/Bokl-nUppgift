using BoklånUppgift.Model;

namespace BoklånUppgift.Interface
{
    public interface IBook
    {
        public Task<Book> GetByIdAsync(int id);
        public Task<List<Book>> GetAllAsync();
        public Task<Book> ReturnBookAsync(int id);
        public Task<Book> RentBookAsync(int id);

    }
}
