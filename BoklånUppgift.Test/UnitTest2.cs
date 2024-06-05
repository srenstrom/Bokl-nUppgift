using BoklånUppgift.Data;
using BoklånUppgift.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoklånUppgift.Test
{
    public class UnitTest2 : IDisposable
    {

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "StudentDbTest")
            .Options;

        ApplicationDbContext context;
    

        public UnitTest2()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            //Seeda databasen
            SeedDatabase();
           
        }

        private void SeedDatabase()
        {
            List<Author> authors = new List<Author>()
    {
        new Author() { AuthorId = 1, FirstName = "Test", LastName = "Testsson" }

    };
            // Create categories
            List<Category> categories = new List<Category>()
    {
        new Category() { CategoryId = 1, CategoryName = "Fiction" },
        new Category() { CategoryId = 2, CategoryName = "Non-Fiction" },
        new Category() { CategoryId = 3, CategoryName = "Science" },
        new Category() { CategoryId = 4, CategoryName = "Fantasy" }
    };
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    BookId=1,
                    Title="Bok ett",
                    Description="Kul",
                    Category=categories[0],
                    YearOfPublishing=1990,
                    Author=authors[0],
                    IsRented=false

                }

            };
            context.Books.AddRange(books);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
        [Fact]
        public void FindBookSuccess()
        {
            //Arrange
            Book book;

            //Act
            book = context.Books.Find(1);

            //Assert
            Assert.Equal("Bok ett", book.Title);
        }
        [Fact]
        public void FindBookNotSuccess()
        {
            //Arrange
            Book book;

            //Act
            book = context.Books.Find(1);

            //Assert
            Assert.Equal("Bok två", book.Title);
        }
    }
}
