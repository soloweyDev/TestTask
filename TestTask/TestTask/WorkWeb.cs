using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

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

            HttpResponseMessage response = await _client.GetAsync($"{UrlApi}0RpLbQ19");

            if (!CheckResponse(response, "Categories")) return list;

            string str = await response.Content.ReadAsStringAsync();

            var doc = new XmlDocument();
            doc.LoadXml(str);

            XmlNodeList xmlNodeList = doc.FirstChild.ChildNodes;

            foreach (var node in xmlNodeList)
            {
                var temp = node as XmlElement;
                if (temp != null)
                    list.ListCategories.Add(new Categories.Category
                                            {
                                                Id = int.Parse(temp.GetAttribute("id")),
                                                Name = temp.GetAttribute("name"),
                                                Parent = int.Parse(temp.GetAttribute("parent")),
                                                Image = temp.GetAttribute("image")
                                            });
            }

            return list;
        }

        public async Task<ErrorCodes> GetErrorCodesAsync()
        {
            var list = new ErrorCodes();

            HttpResponseMessage response = await _client.GetAsync($"{UrlApi}JK7WiMax");

            if (!CheckResponse(response, "Categories")) return list;

            string str = await response.Content.ReadAsStringAsync();

            var doc = new XmlDocument();
            doc.LoadXml(str);

            XmlNodeList xmlNodeList = doc.FirstChild.ChildNodes;

            foreach (var node in xmlNodeList)
            {
                var temp = node as XmlElement;
                if (temp != null)
                    list.ListErrorCodes.Add(new ErrorCodes.ErrorCode
                                            {
                                                Code = temp.GetAttribute("code"),
                                                Text = temp.GetAttribute("text")
                                            });
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
