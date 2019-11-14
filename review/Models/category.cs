using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace review.Models
{
    public class category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }
        public ICollection<subcategory> subcategory { get; set; }
        public ICollection<product> product { get; set; }

    }
}