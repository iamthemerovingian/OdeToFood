using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        [Required]
        [StringLength(maximumLength: 1024, MinimumLength = 5)]
        public string Body { get; set; }

        [Display(Name ="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }
}