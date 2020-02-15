using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTask
{
    public class WorkWeb
    {
        private readonly HttpClient _client;
        private string UrlApi { get; } = "https://pastebin.com/raw/";

        public WorkWeb()
        {
            _client = new HttpClient();
        }

        public async Task<Categories> GetCategoriesAsync()
        {
            var list = new Categories();

            HttpResponseMessage response = await _client.GetAsync($"{UrlApi}JK7WiMax");

            if (!CheckResponse(response, "Categories")) return list;

            string str = await response.Content.ReadAsStringAsync();

            using (TextReader textReader = new StringReader(str))
            {
                var xml = new XmlSerializer(typeof(Categories));
                list = xml.Deserialize(textReader) as Categories;
            }

            return list;
        }

        public async Task<ErrorCodes> GetErrorCodesAsync()
        {
            var list = new ErrorCodes();

            HttpResponseMessage response = await _client.GetAsync($"{UrlApi}JK7WiMax");

            if (!CheckResponse(response, "Categories")) return list;

            string str = await response.Content.ReadAsStringAsync();

            using (TextReader textReader = new StringReader(str))
            {
                var xml = new XmlSerializer(typeof(ErrorCodes));
                list = xml.Deserialize(textReader) as ErrorCodes;
            }

            return list;
        }

        private static bool CheckResponse(HttpResponseMessage response, string exchangeName)
        {
            if (response != null && response.StatusCode == HttpStatusCode.OK) return true;

            Console.WriteLine($"Сервер биржи {exchangeName} возвращает ошибку: {response?.StatusCode ?? HttpStatusCode.BadRequest}");
            return false;
        }
    }
}
