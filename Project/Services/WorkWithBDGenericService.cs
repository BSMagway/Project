using Project.Interfaces.Services;
using ProjectCommon.Models;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Project.Services
{
    internal class WorkWithBDGenericService<T> : IWorkWithBDGeneric<T>
    {
        static HttpClient httpClient = new HttpClient();

        static JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        public async Task<ObservableCollection<T>> GetAll(string address)
        {
            using var response = await httpClient.GetAsync(address);

            var items = new ObservableCollection<T>();

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception();
            }
            else
            {
                items = await response.Content.ReadFromJsonAsync<ObservableCollection<T>>();
            }

            return items;
        }

        public async Task<T> Get(string address, int id)
        {
            var item = default(T);

            using var response = await httpClient.GetAsync(address + "/" + id);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception();
            }
            else
            {
                item = await response.Content.ReadFromJsonAsync<T>();
            }

            return item;
        }

        public async Task<T> Add(string address, T item)
        {
            JsonContent content = JsonContent.Create(item, null, optionsCyr);

            using var response = await httpClient.PostAsync(address, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception();
            }
            else
            {
                item = await response.Content.ReadFromJsonAsync<T>();
            }

            return item;
        }

        public async Task Update(string address, T item)
        {
            JsonContent content = JsonContent.Create(item, null, optionsCyr);

            using var response = await httpClient.PutAsync(address, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception();
            }
        }

        public async Task Delete(string address, int id)
        {
            using var response = await httpClient.DeleteAsync(address + "/" + id);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception();
            }
        }
    }
}
