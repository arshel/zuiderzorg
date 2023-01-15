using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using zuiderzorg.Models;
using Npgsql;
using System.Linq;
using zuiderzorg.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;
using System.Globalization;

namespace zuiderzorg.Pages
{
    public class Product_Select_PageModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty] public string Option { get; set; }
        [BindProperty] public IFormFile? FileUpload { get; set; }
        [BindProperty] public CategoryContext CategoryRequest { get;set;}
        public IActionResult OnPost()
        {
            string op = Request.Form["Option"];
            switch (op)
            {
                case "Add":
                    using (var db = new CategoryContext())
                    {
                        //Creating a new item and saving it to the database
                        var newCatergory = new Category();
                        newCatergory.Name = Request.Form["CategoryName"];
                        if (FileUpload != null)
                        {
                            var filePath = Path.Combine("./wwwroot/images/", FileUpload.FileName);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                FileUpload.CopyTo(stream);
                            }

                            newCatergory.Image = FileUpload.FileName;
                        }
                        else
                        {
                            newCatergory.Image = "CatagoryIcons/InfoIcon.png";
                        }
                        //newCatergory.Name = CategoryRequest.Name;
                        db.Categories.Add(newCatergory);
                        db.SaveChanges();

                    }
                    op = ""; 
                    return RedirectToPage("Product_Select_Page");

                case "Edit":
                    using (var db = new CategoryContext())
                    {
                        var CategoryToEdit = db.Categories.Where(x => x.CategoryId == Guid.Parse(Request.Cookies["CategoryId"])).ToList();
                        if (CategoryToEdit.Any())
                        {
                            CategoryToEdit[0].Name = Request.Form["CategoryName"];
                            if (FileUpload != null)
                                CategoryToEdit[0].Image = FileUpload.FileName;
                            else if (CategoryToEdit[0].Image == null)
                                CategoryToEdit[0].Image = "CatagoryIcons/InfoIcon.png";
                            db.SaveChanges();
                        }

                    }
                    op = "";
                    return RedirectToPage("Product_Select_Page");

                case "Remove":
                    using (var db = new CategoryContext())
                    {
                        var CategoryToRemove = db.Categories.Where(x => x.CategoryId == Guid.Parse(Request.Cookies["CategoryId"])).ToList();
                        if (CategoryToRemove.Any())
                        {
                            db.Categories.Remove(CategoryToRemove[0]);
                            db.SaveChanges();
                        }

                    }
                    op = "";
                    return RedirectToPage("Product_Select_Page");

                default:
                    op = "";
                    return RedirectToPage("Product_Select_Page");
            }
        }
        public Category[] GetCategories()
        {
            using var db = new CategoryContext();
            var CatNames = db.Categories.ToArray();
            return CatNames;

        }
    }
}
