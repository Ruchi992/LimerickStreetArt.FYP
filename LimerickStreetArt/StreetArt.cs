namespace LimerickStreetArt
{
	using System;
	public class StreetArt
	{
		public int Id { get; set; }

		public static float GpsLatitude
		{
			get;
			set;
		}
		public static float GpsLongitude
		{
			get;
			set;
		}
		public static String Title
		{
			get;
			set;
		}
		public  static String Street
		{
			get;
			set;
		}
		public static DateTime Timestamp
		{
			get;
			set;
		}
		public static String Image
		{
			get;
			set;
		}
		public static int UserAccountId
		{
			get;
			set;
		}
	}

}
