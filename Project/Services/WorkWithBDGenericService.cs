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

        public async Task<ObservableCollection<T>> GetAll(string adress)
        {
            using var response = await httpClient.GetAsync(adress);

            var items = new ObservableCollection<T>();

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                items = await response.Content.ReadFromJsonAsync<ObservableCollection<T>>();
            }

            return items;
        }

        public async Task<T> Get(string adress, int id)
        {
            var item = default(T);

            using var response = await httpClient.GetAsync(adress + id);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                item = await response.Content.ReadFromJsonAsync<T>();
            }

            return item;
        }

        public async Task<T> Add(string adress, T item)
        {
            JsonContent content = JsonContent.Create(item, null, optionsCyr);

            using var response = await httpClient.PostAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                item = await response.Content.ReadFromJsonAsync<T>();
            }

            return item;
        }

        public async Task Update(string adress, T item)
        {
            JsonContent content = JsonContent.Create(item, null, optionsCyr);

            using var response = await httpClient.PutAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
        }

        public async Task Delete(string adress, int id)
        {
            using var response = await httpClient.DeleteAsync(adress + id);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
        }
    }
}
