using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SocialBook
{
    [Activity(Label = "@string/app_name")]
    class CommentActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.comments_main);
            var list = FindViewById<ListView>(Resource.Id.commentsListView);
            list.Adapter = new CommentsAdapter(this, Values.comments);

            var commentBtn = FindViewById<Button>(Resource.Id.commentBtn);
            commentBtn.Click += CommentBtn_Click;
        }

        private void CommentBtn_Click(object sender, EventArgs e)
        {
            string comment = FindViewById<TextView>(Resource.Id.insertText).Text;
            Values.comments.Add(new CommentData
            {
                Message = comment,
                Name = "Opilane"
            });
            var list = FindViewById<ListView>(Resource.Id.commentsListView);
            list.Adapter = new CommentsAdapter(this, Values.comments);
        }
    }
}