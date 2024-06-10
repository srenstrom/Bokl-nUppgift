using BoklånUppgift.Controllers;
using BoklånUppgift.Data;
using BoklånUppgift.Interface;
using BoklånUppgift.Model;
using BoklånUppgift.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoklånUppgift.Test
{
    public class UnitTest2 : IDisposable
    {

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDatabaseTest")
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
        new Author() { AuthorId = 1, FirstName = "Lars", LastName = "Kepler" },
        new Author() { AuthorId = 2, FirstName = "Stephen", LastName = "King" }

    };
            // Create categories
            List<Category> categories = new List<Category>()
    {
        new Category() { CategoryId = 1, CategoryName = "Spänning" },
        new Category() { CategoryId = 3, CategoryName = "Fakta" },
        new Category() { CategoryId = 4, CategoryName = "Thriller" },
        new Category() { CategoryId = 5, CategoryName = "Skräck" }
    };
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    BookId=1,
                    Title="Sömngångaren",
                    Description="Sömngångaren är Lars Keplers tionde bok om Joona Linna.",
                    Category=categories[2],
                    YearOfPublishing=2024,
                    Author=authors[0],
                    IsRented=false

                },
                new Book()
                {
                    BookId=2,
                    Title="Staden som försvann",
                    Description="Staden som försvann är Stephen Kings andra utgivna roman",
                    Category=categories[3],
                    YearOfPublishing=1975,
                    Author=authors[1],
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
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            var bookRepository = new BookRepository(context);

            // Act
            List<Book> result = await bookRepository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);


        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnBookById()
        {
            // Arrange
            var bookRepository = new BookRepository(context);
            int id = 2;

            // Act
            Book result = await bookRepository.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.BookId);
            Assert.Equal("Staden som försvann", result.Title);
            Assert.Equal("Skräck", result.Category.CategoryName);
            Assert.Equal("Stephen King", $"{result.Author.FirstName} {result.Author.LastName}");
            Assert.Equal("Staden som försvann är Stephen Kings andra utgivna roman", result.Description);
            Assert.False(result.IsRented);
        }

    }

}

