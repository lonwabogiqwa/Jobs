using Jobs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jobs.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        // GET: Job
        public async Task<ActionResult> Index()
        {
            List<Job> model = null;
            var client = new HttpClient();

            // .NET 4.5 async await pattern
            var task = await client.GetAsync("https://gist.githubusercontent.com/WillemLabu/34cfb50187ec334c48ee/raw/cb46400505afd82d9e354b591ad71d97f07613be/jobs.json");
            var jsonString = await task.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<List<Job>>(jsonString);
            return View(model);
        }
    }
}
