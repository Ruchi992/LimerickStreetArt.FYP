using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArtApp.Models
{
	public enum MenuItemType
	{
		Search,
		AboutTheArt,
		Login,

	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }


	}
}
