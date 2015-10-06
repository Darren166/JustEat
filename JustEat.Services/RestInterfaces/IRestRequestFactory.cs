namespace JustEat.RestInterfaces
{
	public interface IRestRequestFactory
	{
		RestSharp.IRestRequest CreateRestaurantByOutcodeRequest(string outcode);
	}
}
