using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItauProj.Web.Services
{
    public static class HttpHelper
    {
        /// <summary>
        /// Efetua requesição Http que retorna um Json Convertido em objeto
        /// </summary>
        /// <typeparam name="T"> Tipo do objeto de retorno </typeparam>
        /// <param name="url">Url de busca</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                throw new HttpRequestException( await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Efetua requesição http (POST) e retorna um objeto json
        /// </summary>
        /// <typeparam name="T">tipo de objeto de retorno</typeparam>
        /// <typeparam name="D">tido de objeto de request</typeparam>
        /// <param name="url"> url da solictação</param>
        /// <param name="data"> objeto a ser efetuado post</param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T,D>(string url, D data)
        {
            HttpClient httpClient = new HttpClient();


            var response = await httpClient.PostAsJsonAsync<D>(url, data);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Efetua requesição http (POST) e retorna um texto
        /// </summary>
        /// <typeparam name="D">tido de objeto de request</typeparam>
        /// <param name="url"> url da solictação</param>
        /// <param name="data"> objeto a ser efetuado post</param>
        /// <returns></returns>
        public static async Task<string> PostAsync<D>(string url, D data)
        {
            HttpClient httpClient = new HttpClient();


            var response = await httpClient.PostAsJsonAsync<D>(url, data);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Efetua requesição http (POST) e retorna um objeto json
        /// </summary>
        /// <typeparam name="T">tipo de objeto de retorno</typeparam>
        /// <typeparam name="D">tido de objeto de request</typeparam>
        /// <param name="url"> url da solictação</param>
        /// <param name="data"> objeto a ser efetuado post</param>
        /// <returns></returns>
        public static async Task<T> PutAsync<T, D>(string url, D data)
        {
            HttpClient httpClient = new HttpClient();


            var response = await httpClient.PutAsJsonAsync<D>(url, data);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Efetua requesição http (POST) e retorna um texto
        /// </summary>
        /// <typeparam name="D">tido de objeto de request</typeparam>
        /// <param name="url"> url da solictação</param>
        /// <param name="data"> objeto a ser efetuado post</param>
        /// <returns></returns>
        public static async Task<string> PutAsync<D>(string url, D data)
        {
            HttpClient httpClient = new HttpClient();


            var response = await httpClient.PutAsJsonAsync<D>(url, data);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Efetua requesição Http de delete que retorna uma mensagem
        /// </summary>
        /// <param name="url">Url de busca</param>
        /// <returns></returns>
        public static async Task<string> DeleteAsync(string url)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }
        }


        public static string GetBaseUrl()
        {
            return "https://localhost:5000/api";
        }


    }

    
}
