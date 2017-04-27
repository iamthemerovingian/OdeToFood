using OdeToFood.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    
    public class RestaurantReview :  IValidatableObject
    {
       
        public int Id { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        [Required(ErrorMessageResourceType =typeof(OdeToFood.Views.Home.Resources), ErrorMessageResourceName ="Greeting")]
        [StringLength(maximumLength: 1024, MinimumLength = 5)]
        public string Body { get; set; }

        [Display(Name ="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        [MaxWords(maxWords: 1)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("milinda"))
            {
                yield return new ValidationResult($"Sorry {ReviewerName}, you can't do this!");
            }
        }
    }
}