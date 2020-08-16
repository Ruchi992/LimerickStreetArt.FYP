using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.MobileForms.Services
{
	public class ApiServiceFactory
	{
		static bool debug = true;
		public static ApiServices GetApiServices()
		{
			if (debug)
				return new ApiServicesMockComponent();
			else
				return new ApiServicesComponent();
		}
	}
}
