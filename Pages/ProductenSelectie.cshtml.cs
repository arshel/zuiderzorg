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

        public static Product[] GetProducts(string CategoryID)
        {
           var db = new CategoryContext();
           return db.Products.Where(x=>x.ParentCategoryId==Guid.Parse(CategoryID)).ToArray();
        }

    }

    
    public class ProductRequest{
        public string Name { get;set;}
        public string Description { get;set;}
        public decimal Price { get;set;}

    }

}
