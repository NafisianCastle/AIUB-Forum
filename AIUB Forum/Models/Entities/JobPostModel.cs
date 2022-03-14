using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class JobPostModel
    {
        public int JpId { get; set; }
        public System.DateTime JpCreationDate { get; set; }
        public Nullable<System.DateTime> JpDeleteDate { get; set; }
        public int Views { get; set; }
        public string Body { get; set; }
        public int JobId { get; set; }
        public string Title { get; set; }
    }
}