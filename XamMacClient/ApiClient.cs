using System;
using System.Threading.Tasks;
namespace SharedClient
{
	public class ApiClient
	{
		public string Endpoint { get; set; }

		public string ApiKey { get; set; }

		public Task<string> GetReplyAsync(string payload)
		{
			return Task.FromResult(payload);
		}
	}
}
