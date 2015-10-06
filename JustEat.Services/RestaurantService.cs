using JustEat.Models;
using JustEat.RestInterfaces;
using System.Collections.Generic;
using System.Net;

namespace JustEat.Services
{
	public class RestaurantService
	{
		public RestaurantService(IRestClientFactory restClientFactory, IRestRequestFactory restRequestFactory)
		{
			this.restClientFactory = restClientFactory;
			this.restRequestFactory = restRequestFactory;
		}

		private readonly IRestClientFactory restClientFactory;
		private readonly IRestRequestFactory restRequestFactory;

		public List<Restaurant> GetRestaurantsByOutcode(string outcode)
		{
			var restClient = restClientFactory.Create();
			var restRequest = restRequestFactory.CreateRestaurantByOutcodeRequest(outcode);
			var response = restClient.Execute<RestaurantDataRoot>(restRequest);

			var restaurantData = response.StatusCode == HttpStatusCode.OK ? response.Data.Restaurants : new List<Restaurant>();

			return restaurantData;
		}
	}
}
