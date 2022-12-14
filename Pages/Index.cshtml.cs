
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using zuiderzorg.Models;
using Npgsql;
using System.Linq;
using zuiderzorg.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions; 

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
        
        /*
         var salt = Salt.Create();
         var hash = Hash.Create("admin", salt);
       
         using (var db = new UserContext())
             {
                 // Creating a new item and saving it to the database
                var newUser = new User();
                 newUser.Email = "123@gmail.com";
                 newUser.HashSalt = salt;
                 newUser.HashPassword = hash;
                 db.Users.Add(newUser);
                 db.SaveChanges();
  
             }
         */
    }

    public string? danger;
    public string? success;
    [BindProperty]
     public LoginRequest? LoginRequest { get; set; }
    public IActionResult OnPost()
        {
            string? returnUrl = null;
            returnUrl = returnUrl ?? Url.Content("~/");
               if (!ModelState.IsValid) {
                return Page();
            }
            using(var db = new UserContext()) {
              
                
                // Get the user with the email
                
                var maybeUser = db.Users.FirstOrDefault(x => x.Email == LoginRequest.Email);
                if (maybeUser == null) {
                    // User does not exist
                    danger = "Deze combinatie email en wachtwoord is onjuist.";
                    return Page();
                }
               

                 var passwordCorrect =  Hash.Validate(LoginRequest.Password, maybeUser.HashSalt, maybeUser.HashPassword);
                
                // Validate password is correct
               
                if (!passwordCorrect) {
                    danger = "Deze combinatie email en wachtwoord is onjuist.";
                    return Page();
                }

                // Create a JWT token and set JWTAuthToken Cookie
                var jwt = new Jwt();
                var token = jwt.Create(maybeUser);
                var cookieOpts = new CookieOptions{
                    MaxAge = token.TimeSpan,
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                };
                Response.Cookies.Append("JWTAuthToken", token.Token, cookieOpts);

                success = "Je bent nu ingelogd!!";
                return LocalRedirect(returnUrl);

            }

           
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                
                  
                
                
                
            
            // If we got this far, something failed, redisplay form
            
        }

          public PartialViewResult OnGetLoginPartial()
        {
            return Partial("_ToLogin");
        }

    


}


public class LoginRequest {
        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Email is niet geldig.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
      
        public string? Password { get; set; }
    }
