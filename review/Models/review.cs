using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace review.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string content { get; set; }
        public int rating { get; set; }
        public DateTime dape_post { get; set; }
        public int productId { get; set; }
        public virtual product Product { get; set; }

     //   [ForeignKey("user")]
        public int userId { get; set; }
        public virtual user user { get; set; }

        //[ForeignKey("user")]
        //public int userId { get; set; }
        //public virtual user user { get; set; }
    }
}