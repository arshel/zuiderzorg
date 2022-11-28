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
    public class ProductenSelectie : PageModel
    { 
        public void OnGet()
        {
        }
        [BindProperty]
        public ProductRequest ProductRequest { get;set;}
        public IActionResult OnPost()
        {
            using (var db = new ProductContext())
            {
                //Creating a new item and saving it to the database
                var NewProduct = new Product();
                NewProduct.Name = Request.Form["title"];
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
            var db = new ProductContext();
            var ProductNames = db.Products.ToArray();
            return ProductNames;

        }

       
    }
    public class ProductRequest{
        public string Name { get;set;}

    }

}
