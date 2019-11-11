using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace review.Models
{
    public class suggestion
    {
        [Key]
        public int sId { get; set; }
        public string email { get; set; }
        public string suggest { get; set; }
    }
}