using javax.jws;
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

        [WebMethod]
        public static string GetProducts(string CategoryID)
        {
            return "succes";
            Guid ID = Guid.Parse(CategoryID);
            /*var db = new CategoryContext();
            var ProductNames = db.Products.ToArray();
            return ProductNames;
            var db = new CategoryContext();
            var ProductInfo =
                from p in db.Products
                join c in db.Categories on p.ParentCategoryId equals c.CategoryId
                select new
                {
                    Product = p.Name,
                    Id = p.ProductId
                };*/
        }

    }

    
    public class ProductRequest{
        public string Name { get;set;}

    }

}
