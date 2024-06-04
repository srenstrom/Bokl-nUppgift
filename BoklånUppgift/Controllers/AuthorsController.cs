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
    public class AuthorsController : Controller
    {
        
        private readonly IAuthor authorRepo;

        public AuthorsController(IAuthor authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            try
            {
                var authors = await authorRepo.GetAllAsync();
                return View(authors);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the author by id
            var author = await authorRepo.GetByIdAsync(id);

            // Check if the author is found
            if (author == null)
            {
                return NotFound();
            }

            // Return the author to the view
            return View(author);
        }


        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,FirstName,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
               await authorRepo.AddAsync(author);
                
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        

        

       
    }
}
