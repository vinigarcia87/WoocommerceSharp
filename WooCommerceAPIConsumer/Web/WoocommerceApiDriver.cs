namespace SharpCommerce.Web
{
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;


    // Returns an individual HTTP Header value
    // Source: http://stackoverflow.com/a/36433357/1003020
    public static class HttpResponseMessageExtensions
    {
        public static string GetHeaderValue(this HttpResponseMessage request, string headerKey)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(headerKey, out keys))
                return null;

            return keys.First();
        }
    }

    public class WoocommerceApiDriver
    {
        private readonly WoocommerceApiUrlGenerator urlGenerator;
        
        internal WoocommerceApiDriver(string storeUrl, string consumerKey, string consumerSecret, string apiRootEndPoint, bool isSsl = false, bool queryStringAuth = false)
        {
            this.urlGenerator = new WoocommerceApiUrlGenerator(storeUrl, consumerKey, consumerSecret, apiRootEndPoint, isSsl, queryStringAuth);
        }

        internal async Task<string> Delete(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return await MakeApiUploadStringCall(HttpMethod.Delete, apiEndpoint, parameters, jsonData);
        }

        internal async Task<string> Post(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return await MakeApiUploadStringCall(HttpMethod.Post, apiEndpoint, parameters, jsonData);
        }

        internal async Task<string> Put(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return await MakeApiUploadStringCall(HttpMethod.Put, apiEndpoint, parameters, jsonData);
        }

        internal async Task<string> Get(string apiEndpoint, Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            return await MakeApiDownloadStringCall(apiEndpoint, parameters, headerParams);
        }

        // Basis for GET
        private async Task<string> MakeApiDownloadStringCall(string apiEndpoint, Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            var url = urlGenerator.GenerateRequestUrl(HttpMethod.Get, apiEndpoint, parameters);
            using (var client = new HttpClient())
            {
                // Specify to use TLS 1.2 as default connection
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;

                client.DefaultRequestHeaders.Authorization = this.urlGenerator.HttpBasicAuth();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    dynamic returnedError = JsonConvert.DeserializeObject<ExpandoObject>(jsonResult, new ExpandoObjectConverter());
                    throw new Exception("[" + ((int)response.StatusCode).ToString() + ": " + response.ReasonPhrase + "] " + returnedError.code + ": " + returnedError.message);
                }

                if (headerParams != null)
                {
                    // Return the total of items of this request, ignoring the pagination
                    int wpTotal;
                    if (int.TryParse(response.GetHeaderValue("X-WP-Total"), out wpTotal))
                        headerParams.RequestTotalItems = wpTotal;

                    // Return the total of pages that this request generate
                    int wpTotalPages;
                    if (int.TryParse(response.GetHeaderValue("X-WP-TotalPages"), out wpTotalPages))
                        headerParams.RequestTotalPages = wpTotalPages;
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
        
        // Basis for PUT, POST, and DELETE
        private async Task<string> MakeApiUploadStringCall(HttpMethod httpMethod, string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            var url = this.urlGenerator.GenerateRequestUrl(httpMethod, apiEndpoint, parameters);
            using (var client = new HttpClient())
            {
                // Specify to use TLS 1.2 as default connection
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;

                using (var content = new StringContent(jsonData ?? string.Empty))
                {
                    client.DefaultRequestHeaders.Authorization = this.urlGenerator.HttpBasicAuth();
                    //client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response;
                    switch (httpMethod)
                    {
                        case HttpMethod.Post:
                            response = await client.PostAsync(url, content);
                            break;
                        case HttpMethod.Put:
                            response = await client.PutAsync(url, content);
                            break;
                        case HttpMethod.Delete:
                            response = await client.DeleteAsync(url);
                            break;
                        default:
                            throw new ArgumentException("Only POST, PUT, and DELETE allowed for this HTTP Method");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        dynamic returnedError = JsonConvert.DeserializeObject<ExpandoObject>(jsonResult, new ExpandoObjectConverter());
                        throw new Exception("[" + ((int)response.StatusCode).ToString() + ": " + response.ReasonPhrase + "] " + returnedError.code + ": " + returnedError.message);
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

    }
}
