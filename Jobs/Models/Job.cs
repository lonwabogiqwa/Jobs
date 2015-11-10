using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Jobs.Models
{
   
    public class Job
    {
        //public int jobnumber {get;set;}
        public string client { get; set; }
        public string jobname {get;set;}
        public DateTime due { get; set; }
        public string status { get; set; }

    }
}