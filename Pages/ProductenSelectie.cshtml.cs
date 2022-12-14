using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using zuiderzorg.Models;

namespace zuiderzorg.Pages
{
    public class ProductenSelectie : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public IFormFile FileUpload { get; set; }
        [BindProperty]
        public ProductRequest ProductRequest { get; set; }
        public IActionResult OnPost()
        {
            using (var db = new CategoryContext())
            {
                Console.WriteLine(FileUpload.FileName);
                var filePath = Path.Combine("./wwwroot/images/", FileUpload.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    FileUpload.CopyTo(stream);
                }

                //Creating a new item and saving it to the database
                var NewProduct = new Product();
                NewProduct.Name = Request.Form["ProductTitle"];
                NewProduct.Description = Request.Form["ProductDescription"];
                NewProduct.PriceMin = decimal.Parse(Request.Form["ProductPriceMin"], CultureInfo.InvariantCulture.NumberFormat);
                NewProduct.PriceMax = decimal.Parse(Request.Form["ProductPriceMax"], CultureInfo.InvariantCulture.NumberFormat);
                NewProduct.ProductId = Guid.NewGuid();
                NewProduct.ParentCategoryId = Guid.Parse(Request.Form["CategorieID"]);
                NewProduct.Image = (string)FileUpload.FileName;
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
        public string Name { get;set;}
        public string Description { get;set;}
        public decimal Price { get;set;}

    }

}
