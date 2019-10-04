using WebServer.DTOS;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace WebServer.Models
{
    // This class is not working as intended, 
    // so i'm using token from the uri string after executing request http://127.0.0.1:8080/api/posts/getToken
    public class Authentication
    {
        private int vkAppId = 7157081;
        public async Task GetToken()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://oauth.vk.com/authorize?client_id=" + vkAppId +
            "&display=page&redirect_uri=http://127.0.0.1:8080/api/posts/getPosts&scope=friends&response_type=code&v=5.101");
            HttpResponseMessage response = await client.SendAsync(request);
            HttpContent responseContent = response.Content;
        }
    }
}