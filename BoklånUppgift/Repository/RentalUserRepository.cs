using BoklånUppgift.Interface;
using BoklånUppgift.Model;

namespace BoklånUppgift.Repository
{
    public class RentalUserRepository : IRentalUser
    {
        public Task<Book> RentBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> ReturnBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
