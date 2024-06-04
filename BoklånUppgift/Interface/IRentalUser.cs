using BoklånUppgift.Model;

namespace BoklånUppgift.Interface
{
    public interface IRentalUser
    {
        public Task<Book> RentBookAsync(Book book);
        public Task<Book> ReturnBookAsync(Book book);
    }
}
