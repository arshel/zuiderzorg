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

        [BindProperty] public string Option { get; set; }
        [BindProperty] public IFormFile FileUpload { get; set; }
        [BindProperty] public ProductRequest ProductRequest { get; set; }

        public IActionResult OnPost()
        {
            switch (Request.Form["Option"])
            {
                case "Add":
                    using (var db = new CategoryContext())
                    {
                        //Creating a new item and saving it to the database
                        var NewProduct = new Product();
                        NewProduct.Name = Request.Form["ProductTitle"];
                        NewProduct.Description = Request.Form["ProductDescription"];
                        NewProduct.PriceMin = decimal.Parse(Request.Form["ProductPriceMin"], CultureInfo.InvariantCulture.NumberFormat);
                        NewProduct.PriceMax = decimal.Parse(Request.Form["ProductPriceMax"], CultureInfo.InvariantCulture.NumberFormat);
                        NewProduct.ProductId = Guid.NewGuid();
                        NewProduct.ParentCategoryId = Guid.Parse(Request.Form["CategorieID"]);
                        if (FileUpload != null)
                        {
                            var filePath = Path.Combine("./wwwroot/images/", FileUpload.FileName);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                FileUpload.CopyTo(stream);
                            }

                            NewProduct.Image = FileUpload.FileName;
                        }
                        else
                        {
                            NewProduct.Image = "CatagoryIcons/InfoIcon.png";
                        }
                        db.Products.Add(NewProduct);
                        db.SaveChanges();


                    }
                    return Page();

                case "Edit":
                    using (var db = new CategoryContext())
                    {
                        var ProductToEdit = db.Products.Where(x => x.ProductId == Guid.Parse(Request.Cookies["ProductId"])).ToList();
                        if (ProductToEdit.Any())
                        {
                            ProductToEdit[0].Name = Request.Form["ProductTitle"];
                            ProductToEdit[0].Description = Request.Form["ProductDescription"];
                            ProductToEdit[0].PriceMin = decimal.Parse(Request.Form["ProductPriceMin"], CultureInfo.InvariantCulture.NumberFormat);
                            ProductToEdit[0].PriceMax = decimal.Parse(Request.Form["ProductPriceMax"], CultureInfo.InvariantCulture.NumberFormat);
                            if(FileUpload != null)
                                ProductToEdit[0].Image = FileUpload.FileName;
                            else
                                ProductToEdit[0].Image = "CatagoryIcons/InfoIcon.png";
                            db.SaveChanges();
                        }

                    }
                    return Page();

                case "Remove":
                    using (var db = new CategoryContext())
                    {
                        var ProductToRemove = db.Products.Where(x => x.ProductId == Guid.Parse(Request.Cookies["ProductId"])).ToList();
                        if (ProductToRemove.Any())
                        {
                            db.Products.Remove(ProductToRemove[0]);
                            db.SaveChanges();
                        }

                    }
                    return Page();

                default:
                    return Page();
            }
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
