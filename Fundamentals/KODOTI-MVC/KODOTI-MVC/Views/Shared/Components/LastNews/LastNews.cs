using KODOTI_MVC.Views.Shared.Components.LastNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KODOTI_MVC.Views.Shared.Components.LastNews
{
    public class LastNews : ViewComponent
    {
        public LastNews()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = new List<LastNewsPostModel>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<List<LastNewsPostModel>>();
                }
            }

            return View(result);
        }
    }
}