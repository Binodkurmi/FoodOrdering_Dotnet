using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select the number of persons")]
        public int NumberOfPerson { get; set; }

        [Required(ErrorMessage = "Please select the booking date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBooking { get; set; }
    }
}
