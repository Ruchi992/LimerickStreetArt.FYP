namespace LimerickStreetArt.Web.Models
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
	using System;
    using System.ComponentModel.DataAnnotations;

    public class StreetArtEditModel
	{
		public int Id { get; set; }
		public float GpsLatitude
		{
			get;
			set;
		}
		public float GpsLongitude
		{
			get;
			set;
		}
		public String Title
		{
			get;
			set;
		}
		public String Street
		{
			get;
			set;
		}
		public DateTime Timestamp
		{
			get;
			set;
		}
		[IgnoreMap]
		[Required(ErrorMessage = "Please choose an image")]
		[Display(Name = "Image")]
		public IFormFile Image { get; set; }
	}
}
