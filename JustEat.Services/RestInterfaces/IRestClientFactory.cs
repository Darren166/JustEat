using System;
namespace JustEat.RestInterfaces
{
	public interface IRestClientFactory
	{
		RestSharp.IRestClient Create();
	}
}
