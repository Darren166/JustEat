using RestSharp;

namespace JustEat.RestInterfaces
{
	public class JustEatRestClientFactory : IRestClientFactory
	{
		public IRestClient Create()
		{
			return new RestClient("http://api-interview.just-eat.com/");
		}
	}
}
