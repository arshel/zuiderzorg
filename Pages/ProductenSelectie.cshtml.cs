using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zuiderzorg.Models;
namespace zuiderzorg.Pages
{
    public class ProductenSelectie : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public ProductRequest ProductRequest { get; set; }
        public IActionResult OnPost()
        {
            using (var db = new CategoryContext())
            {
                //Creating a new item and saving it to the database
                var NewProduct = new Product();
                NewProduct.Name = Request.Form["ProductTitle"];
                NewProduct.Description = Request.Form["ProductDescription"];
                NewProduct.Price = decimal.Parse(Request.Form["ProductPrice"]);
                NewProduct.ProductId = Guid.NewGuid();
                NewProduct.ParentCategoryId = Guid.Parse(Request.Form["CategorieID"]);
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

    }

    
    public class ProductRequest{
        public string? Name { get;set;}
        public string? Description { get;set;}
        public decimal? Price { get;set;}

    }

}
