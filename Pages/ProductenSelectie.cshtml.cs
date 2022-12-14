using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zuiderzorg.Pages;

public class ProductenSelectie : PageModel
{
    private readonly ILogger<ProductenSelectie> _logger;

    public ProductenSelectie(ILogger<ProductenSelectie> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

