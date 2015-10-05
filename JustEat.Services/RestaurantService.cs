using JustEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEat.Services
{
    public class RestaurantService
    {
		public List<Restaurant> GetRestaurantsByOutcode(string outcode) {
			return new List<Restaurant> { 
			new Restaurant{
				Id = 1,
				Name = "Test",
				NumberOfRatings = 10,
				RatingStars = 2.0,
				CuisineTypes = new List<CuisineType> {
					new CuisineType {
						Id = 1,
						Name = "Chinese"
					}
				}
			}};
		}
    }
}
