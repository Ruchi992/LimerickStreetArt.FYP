using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LimerickStreetArt.MobileForms
{

	public class CostomView : ViewCell
	{
		public static readonly BindableProperty SelectedItemBackgroundColorProperty = BindableProperty.Create("SelectedItemBackgroundColor", typeof(Color), typeof(CostomView));
		public Color SelectedItemBackgroundColor
		{
			get
			{
				return (Color)GetValue(SelectedItemBackgroundColorProperty);
			}
			set
			{
				SetValue(SelectedItemBackgroundColorProperty, value);
			}
		}
	}
}

