namespace LimerickStreetArt.Web.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	public class LoginModel
	{
		[DataType(DataType.Password)]
		[Required]
		public String Password { get; set; }
		[Display(Name = "Remember Me")]
		public Boolean RememberMe { get; set; }
		[Required]
		public String Username { get; set; }
	}
}