using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class AnswerVoteModel
    {
        public int AnsVoteId { get; set; }
        public int AnsId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
    }
}