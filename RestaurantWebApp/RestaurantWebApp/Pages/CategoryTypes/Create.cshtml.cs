using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.Data;

namespace RestaurantWebApp.Pages.CategoryTypes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                _db.CategoryType.Add(CategoryType);
                await _db.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}