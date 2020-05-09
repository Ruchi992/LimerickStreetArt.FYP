using System;
using System.ComponentModel.DataAnnotations;

namespace LimerickStreetArt.Web.Models
{
	public class RegistrationModel
	{
		[DataType(DataType.Password)]
		[Required]
		public String Password { get; set; }
		[DataType(DataType.Password)]
		[Required]
		public String ReconformPassword { get; set; }
		public String Email { get; set; }
		[Required]
		public String Username { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
	}
}
