using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazer.Model;

namespace BookListRazer.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGetAsync(int id)
        {
            Book = await _db.Book.FindAsync(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var Bookfromdb = await _db.Book.FindAsync(Book.id);
                Bookfromdb.Name = Book.Name;
                Bookfromdb.Author = Book.Author;
                Bookfromdb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();
                Message = "Book has been Edited Succesfully";
                return RedirectToPage("index");
                
            }

            return RedirectToPage();

        }
    }
}