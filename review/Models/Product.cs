
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace review.Models
{
    public class product
    {
        [Key]
        public int Id { get; set; }
        public string productname { get; set; }
        public string img { get; set; }
       // [ForeignKey("category")]
        public string Description { get; set; }
        public string Websites { get; set; }
        public int catId { get; set; }
        public virtual category category { get; set; }
    //    [ForeignKey("subcategory")]
        public int subcatId { get; set; }
        public virtual subcategory subcategory { get; set; }
        public ICollection<Review> review { get; set; }

    }
}