using DevInMotionApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevInMotion.RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private HttpClient _client;
        private readonly ILogger<IndexModel> _logger;
        private const string uri = "https://localhost:44392/api/Agreement";
        public List<Agreement> agreementList { get; set; }


        public IndexModel(ILogger<IndexModel> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
 
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await _client.GetAsync(uri);
            if (response != null)
            {
                var result = await response.Content.ReadAsStringAsync();
                agreementList = JsonConvert.DeserializeObject<IEnumerable<Agreement>>(result).ToList();
                return Page();
            }
            return null;
        }
    }
}
