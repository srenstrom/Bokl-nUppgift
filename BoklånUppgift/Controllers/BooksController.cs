using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoklånUppgift.Data;
using BoklånUppgift.Model;
using BoklånUppgift.Interface;

namespace BoklånUppgift.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBook bookRepo;

        public BooksController(IBook bookRepo)
        {
            
            this.bookRepo = bookRepo;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await bookRepo.GetAllAsync();
                return View(books);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            var books = await bookRepo.GetByIdAsync(id);

            
            if (books == null)
            {
                return NotFound();
            }

            
            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Description,YearOfPublishing,RentDate,IsRented")] Book book)
        {
            if (ModelState.IsValid)
            {
                await bookRepo.AddAsync(book);

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        


    }
}
