using FluentAssertions;
using JustEat.Models;
using JustEat.RestInterfaces;
using JustEat.Services;
using Moq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace JustEat.Tests
{
	[TestFixture]
	public class ServiceTests
	{
		[Test]
		public void GetRestaurantsByOutcode_Returns_Correct_Data_When_API_Call_Succeeds()
		{
			// Given a guaranteed succesful api call
			var outcode = "SE19";
			var restaurantDataRoot = createRestaurantDataRoot();
			var fakedRestClient = createFakedRestClient(restaurantDataRoot, HttpStatusCode.OK);
			var fakedRestClientFactory = createFakeRestClientFactory(fakedRestClient);

			// When we call the service method
			var restaurantService = new RestaurantService(fakedRestClientFactory, new JustEatRestRequestFactory());
			var actual = restaurantService.GetRestaurantsByOutcode(outcode);

			// Then the restaurant list is as expected
			var expected = restaurantDataRoot.Restaurants;
			actual.ShouldBeEquivalentTo(expected);
		}

		[Test]
		public void GetRestaurantsByOutcode_Returns_Empty_List_When_API_Call_Fails()
		{
			// Given a failed api call, regardless of restaurant data returned
			var outcode = "SE19";
			var restaurantDataRoot = new RestaurantDataRoot();
			var fakedRestClient = createFakedRestClient(restaurantDataRoot, HttpStatusCode.NotFound);
			var fakedRestClientFactory = createFakeRestClientFactory(fakedRestClient);

			// When we call the service method
			var restaurantService = new RestaurantService(fakedRestClientFactory, new JustEatRestRequestFactory());
			var actual = restaurantService.GetRestaurantsByOutcode(outcode);

			// Then the restaurant list is empty
			var expected = new List<Restaurant>();
			actual.ShouldBeEquivalentTo(expected);

		}

		private RestaurantDataRoot createRestaurantDataRoot()
		{
			return new RestaurantDataRoot
						{
							Restaurants = new List<Restaurant> { 
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
												}
									}
						};
		}

		private IRestClient createFakedRestClient(RestaurantDataRoot restaurantDataRoot, HttpStatusCode httpStatusCode)
		{
			var mockedRestClient = new Mock<IRestClient>();
			mockedRestClient
				.Setup(restClient => restClient.Execute<RestaurantDataRoot>(It.IsAny<IRestRequest>()))
				.Returns(new RestResponse<RestaurantDataRoot>
				{
					StatusCode = httpStatusCode,
					Data = restaurantDataRoot
				});
			return mockedRestClient.Object;
		}

		private IRestClientFactory createFakeRestClientFactory(IRestClient restClient)
		{
			var mockedRestClientFactory = new Mock<IRestClientFactory>();
			mockedRestClientFactory
				.Setup(factory => factory.Create())
				.Returns(restClient);
			return mockedRestClientFactory.Object;
		}
	}
}
