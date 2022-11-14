using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zuiderzorg.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

<<<<<<< Updated upstream
=======
        // var salt = Salt.Create();
        // var hash = Hash.Create("admin", salt);
       
        // using (var db = new UserContext())
        //     {
        //         // Creating a new item and saving it to the database
        //         var newUser = new User();
        //         newUser.Email = "123@gmail.com";
        //         newUser.HashSalt = salt;
        //         newUser.HashPassword = hash;
        //         db.Users.Add(newUser);
        //         db.SaveChanges();
  
        //     }
>>>>>>> Stashed changes
    }
}
