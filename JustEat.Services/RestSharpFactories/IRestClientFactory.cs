namespace JustEat.Services.RestSharpFactories
{
	public interface IRestClientFactory
	{
		RestSharp.IRestClient Create();
	}
}
