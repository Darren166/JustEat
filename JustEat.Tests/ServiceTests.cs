using System;
using NUnit.Framework;
using System.Collections.Generic;
using JustEat.Services;
using JustEat.Models;
using FluentAssertions;

namespace JustEat.Tests
{
	[TestFixture]
	public class ServiceTests
	{
		[Test]
		public void GetRestaurantsByOutcode_Returns_Correctly()
		{
			// Given an outcode of SE19
			var outCode = "SE19";

			// When we call the service method with that outcode
			var restaurantService = new RestaurantService();
			var actual = restaurantService.GetRestaurantsByOutcode(outCode);

			// Then the restaurant list is as expected
			var expected = new List<Restaurant> { 
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
			actual.ShouldBeEquivalentTo(expected);
		}
	}
}
