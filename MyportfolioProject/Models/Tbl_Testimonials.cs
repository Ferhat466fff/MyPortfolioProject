//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyportfolioProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Testimonials
    {
        public int TestimonialId { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
    }
}
