using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskScheduler.Models
{
    public class task
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Range(1, int.MaxValue,ErrorMessage = "The Created By is required.")]
        [Display(Name = "Created By")]
        public int createdbyid { get; set; }

        [Required]
        [Display(Name = "Assigned To")]
        [Range(1, int.MaxValue, ErrorMessage = "The Assigned To is required.")]
        public int assignedtoid { get; set; }

        [Required]
        [Display(Name = "Task Description")]
        public string taskdescription { get; set; }

        [Display(Name = "Create Date")]
        public DateTime createdate { get; set; }
    }
}