using Microsoft.AspNetCore.Identity;

namespace BoklånUppgift.Model
{
    public class RentalUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
