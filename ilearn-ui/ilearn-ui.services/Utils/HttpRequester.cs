namespace ilearn_ui.services.Utils
{
    public interface IHttpRequester
    {
        Task<HttpResponseMessage> GetAsync(string clientName, string path, CancellationToken cancellationToken = default);

    }
    public class HttpRequester : IHttpRequester
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequester(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetAsync(string clientName, string path, CancellationToken cancellationToken = default)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            var request = new HttpRequestMessage(HttpMethod.Get, GetRequestPath(httpClient, path));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");

            var response = await httpClient.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                await HttpErrorHandler.HandleErrorResponse(response);
            }

            return response;
        }
        private string GetRequestPath(HttpClient httpClient, string endpoint)
        {
            var requestUrl = $"{httpClient.BaseAddress.AbsolutePath}/{endpoint}";

            var requestUrlParts = requestUrl.Split("/", StringSplitOptions.RemoveEmptyEntries);
            requestUrl = String.Join("/", requestUrlParts);

            return $"/{requestUrl}";
        }
    }

}
