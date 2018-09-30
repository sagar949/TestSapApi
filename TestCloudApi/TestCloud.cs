using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace TestCloudApi
{
    public class TestCloud
    {
        public static async Task<HttpResponseMessage> MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("CallerId", "");
            client.DefaultRequestHeaders.Add("api-version", "1.0.0");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "04983169bd3747e8baddc7dc1519129b");

            var uri = "https://sapis.azure-api.net/api/getactions?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(System.IO.File.ReadAllText(@".\body.txt"));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                return response;
            }

        }
    }
}
