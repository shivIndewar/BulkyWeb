using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> CategorieList { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
           _db = db;
        }
        public void OnGet()
        {
            CategorieList = _db.Categories.ToList();
        }
    }
}
