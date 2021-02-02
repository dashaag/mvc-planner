using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class AddViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title: ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public bool IsPriority { get; set; }
        public string Image { get; set; }
    }
}