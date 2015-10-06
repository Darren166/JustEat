using RestSharp;

namespace JustEat.Services.RestSharpFactories
{
	public class JustEatRestClientFactory : IRestClientFactory
	{
		public IRestClient Create()
		{
			return new RestClient("http://api-interview.just-eat.com/");
		}
	}
}
