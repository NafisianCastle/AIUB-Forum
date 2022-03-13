using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class AnswerModel
    {
        public int AnsId { get; set; }
        public string Body { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public int PostId { get; set; }
        public int Score { get; set; }
        public int AnsUserId { get; set; }
    }
}