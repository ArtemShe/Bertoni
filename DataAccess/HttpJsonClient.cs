using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IWebDataProvider
    {
        Task<T> GetAsync<T>(string url);
    }

    public class HttpJsonClient : IWebDataProvider
    {
        public Task<T> GetAsync<T>(string url)
        {
            HttpClient client = new HttpClient();
            return client.GetFromJsonAsync<T>(url);

        }
    }
}
