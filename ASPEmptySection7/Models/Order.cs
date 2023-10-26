using ASPEmptySection7.Attributes.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ASPEmptySection7.Models
{
    public class Order: IValidatableObject 
    {
        [BindNever]
        public int OrderNo { get; set; }
        [Display(Name = "Order date")]
        [Required(ErrorMessage = "You did not enter the {0}")]
        [NotPastDateTime(ErrorMessage = "{0} can not be less than now")]
        public DateTime? OrderDate { get; set; }
        [Required(ErrorMessage = "You did not enter the {0}")]
        [Display(Name = "Invoice Price")]
        public double? InvoicePrice { get; set; }
        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "List of Product")]
        public List<Product>? Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double? sum = Products!.Select(pr => pr.Price * pr.Quantity).Sum();
            if(sum != InvoicePrice)
            {
                yield return new ValidationResult("Invoice Price doesn't match with list of products");
            }
        }
    }
}
