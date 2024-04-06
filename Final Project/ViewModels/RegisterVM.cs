using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Name is required")]
		[StringLength(50)]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Enter your phone number")]
		[StringLength(10)]
		[MaxLength(10)]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Password doesn't match!")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
