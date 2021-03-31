using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NuevoYazilim.Models;

namespace NuevoYazilim.Services
{
    public class LoginService
    {
        string basePath;
        public LoginService()
        {
            basePath= "https://reqres.in/";
        }

        public async Task<int> Login(LoginModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = basePath + "api/login";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var uri = new Uri(url);
                    string serializedObject = JsonConvert.SerializeObject(model);
                    HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, contentPost);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 2;
            }

        }
    }
}
