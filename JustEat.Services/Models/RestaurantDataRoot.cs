using System.Collections.Generic;

namespace JustEat.Models
{
		public class RestaurantDataRoot
		{
			public string ShortResultText { get; set; }
			public List<Restaurant> Restaurants { get; set; }
		}
}
