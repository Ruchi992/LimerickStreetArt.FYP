using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace LimerickStreetArt.Web.Models
{
	public class StreetArtModel
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
		public String Image { get; set; }
	}
}
