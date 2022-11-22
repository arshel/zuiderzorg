using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zuiderzorg.Pages;

public class FavorietenModel : PageModel
{
    private readonly ILogger<BlikModel> _logger;

    public FavorietenModel(ILogger<BlikModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}