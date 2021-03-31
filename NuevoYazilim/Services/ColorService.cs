using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NuevoYazilim.Models;
using static NuevoYazilim.Models.ColorModel;

namespace NuevoYazilim.Services
{
    public class ColorService
    {
        string basePath;
        public ColorService()
        {
            basePath= "https://reqres.in/";
        }

        public async Task<Root> ColorList(ColorModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = basePath + "api/unknown";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var uri = new Uri(url);
                    string serializedObject = JsonConvert.SerializeObject(model);
                    HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Root>(result);
        
                        return data;
                    }
                    else
                    {
                        return new Root();
                    }
                }
            }
            catch (Exception ex)
            {
                return new Root();
            }
        }



        public async Task<Detail> ColorDetail(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = basePath + "api/unknown/" + id;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var uri = new Uri(url);
                    string serializedObject = JsonConvert.SerializeObject(id);
                    HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Detail>(result);

                        return data;
                    }
                    else
                    {
                        return new Detail();
                    }
                }
            }
            catch (Exception ex)
            {
                return new Detail();
            }
        }
    }
}
