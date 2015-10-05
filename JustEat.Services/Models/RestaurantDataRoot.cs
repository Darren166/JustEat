using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEat.Models
{
		public class RestaurantDataRoot
		{
			public string ShortResultText { get; set; }
			public List<Restaurant> Restaurants { get; set; }
		}
}
