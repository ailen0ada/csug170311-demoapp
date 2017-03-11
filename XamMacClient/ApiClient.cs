using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
namespace SharedClient
{
	public class ApiClient
	{
		public string Endpoint { get; set; }

		public string ApiKey { get; set; }

		public async Task<string> GetReplyAsync(string payload)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("x-api-key", ApiKey);
				var response = await client.GetStringAsync($"{Endpoint}?value={payload}");
				return response;
			}
		}
	}
}
