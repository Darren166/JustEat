using RestSharp;

namespace JustEat.RestInterfaces
{
	public class JustEatRestRequestFactory : IRestRequestFactory
	{
		public IRestRequest CreateRestaurantByOutcodeRequest(string outcode)
		{
			var request = new RestRequest("restaurants");
			request.AddParameter("q", outcode);
			request.AddHeader("Accept-Tenant", "uk");
			request.AddHeader("Accept-Language", "en-GB");
			request.AddHeader("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");

			return request;
		}
	}
}
