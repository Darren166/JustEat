namespace JustEat.Services.RestSharpFactories
{
	public interface IRestRequestFactory
	{
		RestSharp.IRestRequest CreateRestaurantByOutcodeRequest(string outcode);
	}
}
