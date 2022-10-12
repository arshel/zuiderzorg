using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

    }

    public string Error;
    public string Success;

    [BindProperty]
    public LoginRequest LoginRequest { get; set; }
    public IActionResult OnPost() {
       
        return Page();
     }


}

public class LoginRequest {
        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Email is niet geldig.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minimaal 6 karakters lang zijn.")]
        public string Password { get; set; }
    }
