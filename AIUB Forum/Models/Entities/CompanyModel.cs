using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int JobPostCount { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CDescription { get; set; }
        public string CCategory { get; set; }
    }
}