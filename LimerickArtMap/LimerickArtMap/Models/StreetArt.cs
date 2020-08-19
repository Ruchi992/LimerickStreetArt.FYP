namespace LimerickStreetArt.MobileForms.Models
{
	using System;
	public class StreetArt
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
		//	TODO: REname to ImageFileName
		public String Image
		{
			get;
			set;
		}
		//	TODO: Rename to AuthorUserAccountId
		public int UserAccountId
		{
			get;
			set;
		}
	}
}
