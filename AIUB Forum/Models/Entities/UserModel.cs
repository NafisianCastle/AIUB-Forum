using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Forum.Models.Entities
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string Views { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public int Reputation { get; set; }
        public byte[] ProfilePic { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}