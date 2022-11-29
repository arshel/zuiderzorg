using System.Collections.Generic;
using System.Globalization;
 
namespace zuiderzorg.Models
{
    public class CultureSwitcherModel
    {
        public CultureInfo? CurrentUICulture { get; set; }
        public List<CultureInfo>? SupportedCultures { get; set; }
    }
}