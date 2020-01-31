using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskScheduler.Models
{
    public class user
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }
    }
}