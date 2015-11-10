using Jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using MR.PagedList.Mvc;


namespace Jobs.Controllers
{
    public class JobController : Controller
    {

        // GET: Job
        private JobList service = new JobList();
        private JobsContext db=new JobsContext();

        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)

        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var jobs = from s in db.Jobs
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.jobname.Contains(searchString)
                                       || s.client.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    jobs = jobs.OrderByDescending(s => s.client);
                    break;
                case "Date":
                    jobs = jobs.OrderBy(s => s.due);
                    break;
                case "date_desc":
                    jobs = jobs.OrderByDescending(s => s.due);
                    break;
                default:
                    jobs = jobs.OrderBy(s => s.status);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
           
            return View("index",
                await service.GetJobsAsync().ToPagedList(pageNumber, pageSize));
            
        }
    }
}