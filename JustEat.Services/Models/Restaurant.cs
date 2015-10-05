using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEat.Models
{
	public class Restaurant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<CuisineType> CuisineTypes { get; set; }
		public double RatingStars { get; set; }
		public int NumberOfRatings { get; set; }
	}
}
