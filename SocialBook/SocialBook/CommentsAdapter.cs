using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SocialBook
{
    class CommentsAdapter : BaseAdapter<CommentData>
    {
        List<CommentData> posts;
        Activity context;

        public CommentsAdapter(Activity context, List<CommentData> items) : base()
        {
            this.context = context;
            this.posts = items;
        }

        public override CommentData this[int position]
        {
            get { return posts[position]; }
        }

        public override int Count { get { return posts.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.comments_base, null);
            }
            view.FindViewById<TextView>(Resource.Id.nameText).Text = posts[position].Name;
            view.FindViewById<TextView>(Resource.Id.commentText).Text = posts[position].Message;

            return view;
        }
    }
}