using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Localization;
namespace zuiderzorg.Services

{
   public class RouteDataRequestCultureProvider : RequestCultureProvider
    {
        private static readonly Regex PartLocalePattern = new Regex(@"^[a-z]{2}(-[a-z]{2,4})?$", RegexOptions.IgnoreCase);
        private static readonly Regex FullLocalePattern = new Regex(@"^[a-z]{2}-[A-Z]{2}$", RegexOptions.IgnoreCase);

        private static readonly Dictionary<string, string> LanguageMap = new Dictionary<string, string>
        {
            { "en", "en-US" },
            { "nl", "nl-NL" }
        };

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var parts = httpContext.Request.Path.Value.Split('/');
            // Get culture from path
            var culture = parts[1];
            System.Diagnostics.Debug.WriteLine(culture);
            if (parts.Length < 3)
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }

            // For full languages fr-FR or en-US pattern
            if (FullLocalePattern.IsMatch(culture))
            {
                return Task.FromResult(new ProviderCultureResult(culture));
            }

            // For part languages fr or en pattern
            if (PartLocalePattern.IsMatch(culture))
            {
                var fullCulture = LanguageMap[culture];
                return Task.FromResult(new ProviderCultureResult(fullCulture));
            }

            return Task.FromResult<ProviderCultureResult>(null);
        }
    }
}