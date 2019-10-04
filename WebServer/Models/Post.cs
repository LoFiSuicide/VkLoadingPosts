using WebServer.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace WebServer.Models
{
    public class Data
    {
        private int numberOfPosts = 5;
        public ResPostDTO deserealizeResponse;
        // Gets 5 posts from user id
        public async Task GetPosts(string token, string ownerId)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.vk.com/method/wall.get?owner_id=" + ownerId +
            "&access_token=" + token + "&count=" + numberOfPosts + "&v=5.52");
            HttpResponseMessage response = await client.SendAsync(request);
            HttpContent responseContent = response.Content;
            string json = await responseContent.ReadAsStringAsync();
            this.deserealizeResponse = JsonConvert.DeserializeObject<ResPostDTO>(json);
        }
        // Posts letter statistics for latest 5 posts in group, responses with post creating page, doesn't wor yet
        public async Task CreatePost(string token, string groupId, string message)
        {
            var client = new HttpClient();
            Console.WriteLine("Message " + message);
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.vk.com/method/wall.post?owner_id=" + groupId + "&access_token="
            + token + "&message=" + message + "&v=5.52&from_group=1");
            await client.SendAsync(request);
        }
    }
}