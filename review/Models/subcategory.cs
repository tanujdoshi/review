using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace review.Models
{
    public class subcategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
      //  [ForeignKey("category")]

        public int catId { get; set; }
        public virtual category category { get; set; }
        public ICollection<product> product { get; set; }

    }
}