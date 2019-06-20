using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using BookListRazer.Model;

namespace BookListRazer.Pages.BookList
{
    public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _DB;

        public CreateModel(ApplicationDbContext db)
        {
            _DB = db;
        }
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _DB.Book.Add(Book);
            await _DB.SaveChangesAsync();
            Message = "Book has been created Successfully";
            return RedirectToPage("Index");
        }
    }
}