namespace SharpCommerce.Web
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class WoocommerceApiDriver
    {
        private readonly WoocommerceApiUrlGenerator urlGenerator;

        internal WoocommerceApiDriver(string storeUrl, string consumerKey, string consumerSecret)
        {
            this.urlGenerator = new WoocommerceApiUrlGenerator(storeUrl, consumerKey, consumerSecret);
        }

        internal string Delete(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Delete, apiEndpoint, parameters, jsonData);
        }

        internal string Post(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Post, apiEndpoint, parameters, jsonData);
        }

        internal string Put(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Put, apiEndpoint, parameters, jsonData);
        }

        internal async Task<string> Get(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            return await MakeApiDownloadStringCall(apiEndpoint, parameters);
        }

        // Basis for GET
        private async Task<string> MakeApiDownloadStringCall(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            var url = urlGenerator.GenerateRequestUrl(HttpMethod.Get, apiEndpoint, parameters);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await client.GetStringAsync(url);
            }
        }
        
        // Basis for PUT, POST, and DELETE
        private string MakeApiUploadStringCall(HttpMethod httpMethod, string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            var url = this.urlGenerator.GenerateRequestUrl(httpMethod, apiEndpoint, parameters);
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                return webClient.UploadString(url, httpMethod.ToString().ToUpper(), jsonData ?? String.Empty);
            }
        }
    }
}
