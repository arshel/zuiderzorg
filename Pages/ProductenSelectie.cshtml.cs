using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using zuiderzorg.Models;
using zuiderzorg.Pages;
using Npgsql;
using System.Linq;
using zuiderzorg.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;

namespace zuiderzorg.Pages
{
    public class ProductenSelectie : PageModel
    { 
        public void OnGet()
        {
        }
        [BindProperty]
        public ProductRequest ProductRequest { get;set;}
        public IActionResult OnPost()
        {
            using (var db = new CategoryContext())
            {
                //Creating a new item and saving it to the database
                var NewProduct = new Product();
                NewProduct.Name = Request.Form["ProductTitle"];
                NewProduct.ProductId = Guid.NewGuid();
                string x = Request.Form["CategorieID"];
                NewProduct.ParentCategoryId = Guid.Parse(x);
                Console.WriteLine(NewProduct.ParentCategoryId);
                //NewProduct.ParentCategoryId = Guid.Parse();
                //newCatergory.Name = CategoryRequest.Name;
                db.Products.Add(NewProduct);
                db.SaveChanges();

            }
            return Page();
        }
        private readonly ILogger<ProductenSelectie> _logger;
        

        public ProductenSelectie(ILogger<ProductenSelectie> logger)
        {
            _logger = logger;
        }

        public Product[] GetProducts()
        {
            var db = new CategoryContext();
            var ProductNames = db.Products.ToArray();
            return ProductNames;

        }

       
    }
    public class ProductRequest{
        public string Name { get;set;}

    }

}
