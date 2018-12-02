using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;

namespace SocialBook
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public List<SocialPost> postList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var listView = FindViewById<ListView>(Resource.Id.listView1);

            #region posts
            postList = new List<SocialPost>();
            SocialPost post1 = new SocialPost
            {
                Name = "kalle Smith",
                Message = "wow cool",
                CommentNumber = "3 Comments",
                Likes = 0,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Picture = this.GetDrawable(Resource.Drawable.images),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "paul",
                        Message = "arge karjuge"
                    },
                    new CommentData
                    {
                        Name = "kalle",
                        Message = "imed taiega"
                    },
                    new CommentData
                    {
                        Name = "Amy",
                        Message = "Buy my phone"
                    }
                }
            };
            postList.Add(post1);
            SocialPost post2 = new SocialPost
            {
                Name = "paul",
                Message = "olen paul",
                CommentNumber = "2 Comments",
                Likes = 200,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "yo",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "Karl",
                        Message = "Buy my phone"
                    }
                }
            };
            postList.Add(post2);
            SocialPost post3 = new SocialPost
            {
                Name = "Robi",
                Message = "Vote for pet rock 2018",
                CommentNumber = "2 Comments",
                Likes = 27,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "harlow",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "tere",
                        Message = "olen taun"
                    }
                }
            };
            postList.Add(post3);
            SocialPost post4 = new SocialPost
            {
                Name = "asd",
                Message = "test",
                CommentNumber = "2 Comments",
                Likes = 2,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "uwu",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "peeter",
                        Message = "Buy pants"
                    }
                }
            };
            postList.Add(post4);
            SocialPost post5 = new SocialPost
            {
                Name = "uku",
                Message = "tere",
                CommentNumber = "1 Comments",
                Likes = 5,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "pille",
                        Message = "AOIhgsiugb<oue"
                    }
                }
            };
            postList.Add(post5);
            #endregion

            var postpost = FindViewById<Button>(Resource.Id.postBtn);
            postpost.Click += Postpost_Click;
            listView.Adapter = new Adapter(this, postList);
            listView.ItemClick += ListView_Click;
        }

        private void Postpost_Click(object sender, EventArgs e)
        {
            string postText = FindViewById<EditText>(Resource.Id.editText1).Text;
            postList.Add(new SocialPost
            {
                Name = "User",
                Message = postText,
                CommentNumber = "0 Comments",
                Likes = 0,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>()
            });
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            FindViewById<EditText>(Resource.Id.editText1).Text = "";
            listView.Adapter = new Adapter(this, postList);
            listView.ItemClick += ListView_Click;
        }

        private void ListView_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var commentActivity = new Intent(this, typeof(CommentActivity));
            Values.comments = postList[e.Position].Comments;
            StartActivity(commentActivity);
        }
    }
}