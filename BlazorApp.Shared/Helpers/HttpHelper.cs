using System.Text;

namespace BlazorApp.Shared.Helpers
{
    public static class HttpHelper
    {
        #region "Fields"
        private readonly static HttpClient httpClient = new();
        #endregion

        public static async Task<string> GetRequest(string route, string endpoint)
        {
            HttpResponseMessage? responseMessage;
            try
            {
                responseMessage = await httpClient.GetAsync(string.Concat(route, endpoint));
                responseMessage.EnsureSuccessStatusCode();
            }
            catch
            {
                return string.Empty;
            }
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public static async Task<string> GetRequest(string route, string endpoint, string data)
        {
            HttpResponseMessage? responseMessage;
            try
            {
                responseMessage = await httpClient.GetAsync(string.Concat(route, endpoint, "/", data));
                responseMessage.EnsureSuccessStatusCode();
            }
            catch
            {
                return string.Empty;
            }
            return await responseMessage.Content.ReadAsStringAsync();
        }
        
        public static async Task<string> PostRequest(string route, string endpoint, string jsonContent)
        {
            HttpResponseMessage? responseMessage;
            try
            {
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                responseMessage = await httpClient.PostAsync(string.Concat(route, endpoint), content);
            }
            catch
            {
                return string.Empty;
            }
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public static async Task<string> PutRequest(string route, string endpoint, string data, string jsonContent)
        {
            HttpResponseMessage? responseMessage;
            try
            {
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                responseMessage = await httpClient.PutAsync(string.Concat(route, endpoint, "/", data), content);
                responseMessage.EnsureSuccessStatusCode();
            }
            catch
            {
                return string.Empty;
            }
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public static async Task<string> DeleteRequest(string route, string endpoint, string data)
        {
            HttpResponseMessage? responseMessage;
            try
            {
                responseMessage = await httpClient.DeleteAsync(string.Concat(route, endpoint, "/", data));
                responseMessage.EnsureSuccessStatusCode();
            }
            catch
            {
                return string.Empty;
            }
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}