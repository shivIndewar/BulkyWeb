using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category category { get; set; }

        public EditModel(ApplicationDBContext db)
        {
                _db = db;   
        }
        public void OnGet(int id)
        {
            category = _db.Categories.Find(id);
        }

        public IActionResult OnPost() 
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
