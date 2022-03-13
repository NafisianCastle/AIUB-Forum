using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class VoteModel
    {
        public int VoteId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
    }
}