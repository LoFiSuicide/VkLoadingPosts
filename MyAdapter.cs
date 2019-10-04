using System.Collections.Generic;
using Android.Content;
using Mobile.DTOS;
using Java.Lang;
using Android.Views;
using Android.Widget;

namespace Mobile
{
    public class MyAdapter : BaseAdapter
    {
        private Context _context;
        private List<PostDTO> _post;
        public MyAdapter(Context context, List<PostDTO> post)
        {
            _post = post;
            _context = context;
        }
        public override int Count => _post.Count;
        public override Object GetItem(int position)
        {
            return null;// throw new System.NotImplementedException();
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var post_item = View.Inflate(_context, Resource.Layout.post_item, null);
            var text = post_item.FindViewById<TextView>(Resource.Id.post_text);
            text.Text = _post[position].text;
            return post_item;
        }
    }
}