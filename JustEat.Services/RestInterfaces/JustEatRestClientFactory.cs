using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEat.RestInterfaces
{
	public class JustEatRestClientFactory
	{
		public IRestClient Create()
		{
			return new RestClient("http://api-interview.just-eat.com/");
		}
	}
}
