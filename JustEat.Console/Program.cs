using JustEat.Models;
using JustEat.RestInterfaces;
using JustEat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JustEat.GUI
{
	class Program
	{
		static void Main(string[] args)
		{
			var outcode = string.Empty;
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Type your outcode and press return, (0 to exit)");
				outcode = Console.ReadLine();
				Console.WriteLine();
				if (outcode == "0") break;

				var restaurantService = new RestaurantService(new JustEatRestClientFactory(), new JustEatRestRequestFactory());
				var restaurants = restaurantService.GetRestaurantsByOutcode(outcode);

				restaurants.ForEach(restaurant => displayRestaurant(restaurant));
			}
		}

		static void displayRestaurant(Restaurant restaurant) {
			Console.WriteLine(restaurant.Name);
			Console.WriteLine(" " + string.Join(", ", restaurant.CuisineTypes.Select(type=>type.Name)));
			Console.WriteLine(" Rated " + restaurant.RatingStars + " stars from " + restaurant.NumberOfRatings + " reviews");
			Console.WriteLine();
		}
	}
}
