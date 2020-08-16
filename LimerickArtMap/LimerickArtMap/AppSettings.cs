using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.MobileForms
{
	public static class AppUrls
	{
		public static int port = 5001;
		public static String service = $"https://localhost:{port}/api/StreetArt/search/";
		public static String login = $"{service}/login/";
		public static String streatArt = $"{streatArt}/StreetArt/";
		public static String streatArtSearch = $"{streatArtSearch}/search/";

	}
}
