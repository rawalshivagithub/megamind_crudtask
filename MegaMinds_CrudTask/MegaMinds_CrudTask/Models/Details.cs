using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMinds_CrudTask.Models
{
    public class Details
    {
		public int Id { get; set; }
		
		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Display(Name = "Phone Number")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Address")]
		public string Address { get; set; }
		
		[Required]
		[Display(Name = "State")]	
        public int StateId { get; set; }
		[ForeignKey(nameof(StateId))]
		public virtual State State { get; set; }

        [Required]
		[Display(Name = "City")]
		public int CityId { get; set; }
		[ForeignKey(nameof(CityId))]
		public virtual City City { get; set; }

    }
}
