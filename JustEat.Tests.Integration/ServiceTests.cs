using FluentAssertions;
using JustEat.RestInterfaces;
using JustEat.Services;
using NUnit.Framework;

namespace JustEat.Tests.Integration
{
	[TestFixture]
	public class ServiceTests
	{
		[Test]
		public void GetRestaurantsByOutcode_Returns_Data_For_The_Outcode_SE19()
		{
			// Given a guaranteed succesful api call
			var outcode = "SE19";

			// When we call the service method
			var restaurantService = new RestaurantService(new JustEatRestClientFactory(), new JustEatRestRequestFactory());
			var actual = restaurantService.GetRestaurantsByOutcode(outcode);

			// Then the restaurant list is not empty
			actual.Count.Should().BeGreaterThan(0);
		}
	}
}
