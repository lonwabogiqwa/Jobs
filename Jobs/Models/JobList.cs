using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Jobs.Models
{
    public class JobList
    {
        readonly string uri = "https://gist.githubusercontent.com/WillemLabu/34cfb50187ec334c48ee/raw/cb46400505afd82d9e354b591ad71d97f07613be/jobs.json";

        public async Task<List<Job>> GetJobsAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<List<Job>>(
                    await httpClient.GetStringAsync(uri)
                );
            }
        }
    }
}
