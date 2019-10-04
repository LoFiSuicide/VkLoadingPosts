using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using System.Threading.Tasks;

namespace WebServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        public Data data = new Data();
        private string appId = "7157081";
        private string ownerId = "71688484";
        private string groupId = "187222053";
        private string token = "";

        [HttpGet("getToken/")]
        public IActionResult GetAuth()
        {
            return Authorization();
        }
        // This method gets token string, but I can't parse it,
        // so I have to manually insert it from uri to private string token
        public IActionResult Authorization()
        {
            // Implicit flow
            return Redirect("https://oauth.vk.com/authorize?client_id=" + appId + "&display=page&redirect_uri=http://127.0.0.1:8080/api/posts/getPosts&scope=friends&response_type=token&v=5.52");
            // Authorization code flow
            // return Redirect("https://oauth.vk.com/authorize?client_id=" + vkAppId + "&display=page&redirect_uri=http://127.0.0.1:8080/api/posts/getPosts&scope=friends&response_type=code&v=5.101");
        }

        [HttpGet("getPosts/")]
        public async Task<ActionResult> Get()
        {
            await data.GetPosts(token, ownerId);
            Frequency frequency = new Frequency(data);
            string message = frequency.CountLetters();
            //CreatePost(message);
            await data.CreatePost(token, groupId, message);
            return Ok(data.deserealizeResponse.response.items);
        }
        //This is experimental method, that has similar purpose as CreatePost in Post.cs, doesn't work yet
        public IActionResult CreatePost(string message)
        {
            return Redirect("https://api.vk.com/method/wall.post?owner_id=187222053&access_token=" 
            + token + "&message=" + message + "&v=5.52&from_group=1");
        }
        [HttpGet("getPosts/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            await data.GetPosts(token, ownerId);
            System.Console.WriteLine("Items " + data.deserealizeResponse.response.items);
            if (data.deserealizeResponse.response.items[id] != null)
                return Ok(data.deserealizeResponse.response.items[id]);
            else
                return NotFound();
        }
    }
}