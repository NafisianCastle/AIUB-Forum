using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Score { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}