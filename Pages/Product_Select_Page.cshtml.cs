using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using zuiderzorg.Models;
using Npgsql;
using System.Linq;
using zuiderzorg.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;

namespace zuiderzorg.Pages
{
    public class Product_Select_PageModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public IFormFile FileUpload { get; set; }
        [BindProperty]
        public CategoryContext CategoryRequest { get;set;}
        public IActionResult OnPost()
        {
            using (var db = new CategoryContext())
            {
                var filePath = Path.Combine("./wwwroot/images/", FileUpload.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    FileUpload.CopyTo(stream);
                }
                //Creating a new item and saving it to the database
                var newCatergory = new Category();
                newCatergory.Name = Request.Form["CategoryName"];
                newCatergory.Image = FileUpload.FileName;
                //newCatergory.Name = CategoryRequest.Name;
                db.Categories.Add(newCatergory);
                db.SaveChanges();

            }
            return Page();
        }
        public Category[] GetCategories()
        {
            using var db = new CategoryContext();
            var CatNames = db.Categories.ToArray();
            return CatNames;

        }
    }
}
