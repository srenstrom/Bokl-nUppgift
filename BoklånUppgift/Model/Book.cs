using System.ComponentModel;

namespace BoklånUppgift.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int YearOfPublishing { get; set; }
        public Category Category { get; set; }
        public DateTime RentDate { get; set; }
        public bool IsRented { get; set; }

    }
}
