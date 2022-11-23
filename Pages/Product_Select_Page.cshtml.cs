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
            GetCategories();
            /*using (var db = new CategoryContext())
            {
                // Creating a new item and saving it to the database
                var newCatergory = new Category();
                newCatergory.Name = "Garden";
                db.Categories.Add(newCatergory);
                db.SaveChanges();

            }*/
        }
        public Category[] GetCategories()
        {
            using var db = new CategoryContext();
            var CatNames = db.Categories.ToArray();
            return CatNames;

        }
    }
}
