using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models
{
	public class Customer : IdentityUser
	{
		[Required(ErrorMessage ="Enter Your Name.")]
        public string Name { get; set; }
    }
}
