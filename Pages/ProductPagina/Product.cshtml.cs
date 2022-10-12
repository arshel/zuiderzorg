using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zuiderzorg.Pages;

public class BlikModel : PageModel
{
    private readonly ILogger<BlikModel> _logger;

    public BlikModel(ILogger<BlikModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

