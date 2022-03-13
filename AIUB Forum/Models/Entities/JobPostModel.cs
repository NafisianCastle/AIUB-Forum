using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class JobPostModel
    {
        public int JPId { get; set; }
        public System.DateTime JPCreationDate { get; set; }
        public Nullable<System.DateTime> JPDeleteDate { get; set; }
        public int Views { get; set; }
        public string Body { get; set; }
        public int JobId { get; set; }
        public string Title { get; set; }
    }
}