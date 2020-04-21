﻿namespace LimerickStreetArt
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
		public String Image
		{
			get;
			set;
		}
		public int UserAccountId
		{
			get;
			set;
		}		
	}
}