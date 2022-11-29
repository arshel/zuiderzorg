
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace zuiderzorg.Pages {
    public class ContactModel : PageModel {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger) {
            _logger = logger;
        }

        public void OnGet() {
           
        }
    }
}
