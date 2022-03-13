using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class AnswerCommentModel
    {
        public int AnsCmntId { get; set; }
        public int AnsId { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}