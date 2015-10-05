using System;
using JustEat.RestInterfaces;
using RestSharp;
using NUnit.Framework;
using FluentAssertions;

namespace JustEat.Tests
{
	[TestFixture]
	public class APIFactoryTests
	{
		//[Test]
		//public void CreateRestClient_Returns_Correctly()
		//{
		//	// Given a rest client factory
		//	var restClientFactory = new JustEatRestClientFactory();

		//	// When the factory is asked to create a rest client
		//	var restClient = restClientFactory.Create();

		//	// Then we get a correctly configured client
		//	restClient.BaseUrl.ShouldBeEquivalentTo("http://api-interview.just-eat.com/");

		//}

		//[Test]
		//public void CreateRestRequest_Returns_Correctly()
		//{
		//	// Given a rest client factory
		//	var restClientFactory = new JustEatRestClientFactory();

		//	// When the factory is asked to create a rest client
		//	var restRequest = restClientFactory.CreateRequuest();

		//	// Then we get a correctly configured client
		//	restRequest.ShouldBeEquivalentTo(new RestRequest{})

		//}
	}
}
