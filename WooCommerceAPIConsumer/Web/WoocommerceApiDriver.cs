namespace SharpCommerce.Web
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

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

                return await response.Content.ReadAsStringAsync();
            }
        }
        
        // Basis for PUT, POST, and DELETE
        private async Task<string> MakeApiUploadStringCall(HttpMethod httpMethod, string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            var url = this.urlGenerator.GenerateRequestUrl(httpMethod, apiEndpoint, parameters);
            using (var client = new HttpClient())
            {
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
