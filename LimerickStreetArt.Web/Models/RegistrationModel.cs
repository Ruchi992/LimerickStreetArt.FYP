using System;
using System.ComponentModel.DataAnnotations;

namespace LimerickStreetArt.Web.Models
{

	public class AddExternalLoginBindingModel
	{
		[Required]
		[Display(Name = "External access token")]
		public string ExternalAccessToken { get; set; }
	}
	public class RegistrationModel
	{


		[DataType(DataType.Password)]
		[Required]
		public String Password { get; set; }
		[DataType(DataType.Password)]
		[Required]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public String ReconformPassword { get; set; }
		public String Email { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]


		public String Username { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
	}
}
