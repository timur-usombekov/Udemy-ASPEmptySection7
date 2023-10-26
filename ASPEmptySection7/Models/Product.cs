using ASPEmptySection7.Attributes.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASPEmptySection7.Models
{
    public class Product
    {
        [Required(ErrorMessage = "You did not enter the {0}")]
        [Display(Name = "Product Code")]
        public int? ProductCode { get; set; }
        [Required(ErrorMessage = "You did not enter the {0}")]
        [NotLessThan(0, ErrorMessage = "{0} Can't be less than zero")]
        [Display(Name = "Price")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "You did not enter the {0}")]
        [NotLessThan(1, ErrorMessage = "{0} Can't be less than one")]
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        public override string ToString()
        {
            return $"ProductCode - {ProductCode}\nPrice - {Price}\nQuantity - {Quantity}";
        }
    }
}
