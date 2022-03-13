//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIUB_Forum.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Score = 0;
            this.views = 0;
            this.AnswerCount = 0;
            this.ComentsCount = 0;
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.Answers = new HashSet<Answer>();
        }
    
        public int PostId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public int Score { get; set; }
        public int views { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public int AnswerCount { get; set; }
        public int ComentsCount { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Votes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
