using System.Collections.Generic;
using System.Net.Http;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Android.Widget;
using Newtonsoft.Json;
using Mobile.DTOS;

namespace Mobile
{
    [Activity(Label = "PostAnalyzer", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var loadButton = FindViewById<Button>(Resource.Id.loadButton);
            loadButton.Click += ButtonClick;

            var list = FindViewById<ListView>(Resource.Id.post_list);
        }
        // For some reason this uri is inaccessible
        private string uri = "https://127.0.0.1:8080/api/posts/getPosts";

        // Sends user id to server, loads posts from server and shows them to user
        private async void ButtonClick(object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(uri);
            var content = await result.Content.ReadAsStringAsync();
            SetContentView(Resource.Layout.activity_main);

            var userId = FindViewById<EditText>(Resource.Id.enterVkId);
            HttpContent idContent = new StringContent(content);

            string json = JsonConvert.SerializeObject(userId.Text);
            HttpContent jsonContent = new StringContent(json);

            HttpResponseMessage response = await client.PostAsync("https://127.0.0.1:8080/api/posts", jsonContent);

            var posts = JsonConvert.DeserializeObject<List<PostDTO>>(content);

            var list = FindViewById<ListView>(Resource.Id.post_list);
            list.Adapter = new MyAdapter(this, posts);
        }

	}
}

