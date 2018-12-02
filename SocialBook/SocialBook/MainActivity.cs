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
                Name = "John Smith",
                Message = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHH!!!!!!!!!!!!",
                CommentNumber = "3 Comments",
                Likes = 0,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Picture = this.GetDrawable(Resource.Drawable.images),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Jake",
                        Message = "REEEEEEEEEEEEEEEEEEEEEEEEEE"
                    },
                    new CommentData
                    {
                        Name = "Peeter",
                        Message = "You suck"
                    },
                    new CommentData
                    {
                        Name = "Amy",
                        Message = "Please stop"
                    }
                }
            };
            postList.Add(post1);
            SocialPost post2 = new SocialPost
            {
                Name = "Gert-Andry Kääramees",
                Message = "oiHAIUSgbuyagbrAGBWRAiuwgrbAWMhvNIANWRgbIAGrniBINUVriANgrAIWNRgbIULARvgbIAWRGnIUGRbNGRIUgb",
                CommentNumber = "2 Comments",
                Likes = 200,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Poppy",
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
                        Name = "Poppy",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "Karl",
                        Message = "Buy my phone"
                    }
                }
            };
            postList.Add(post3);
            SocialPost post4 = new SocialPost
            {
                Name = "Rein",
                Message = "I am vegan, that is all",
                CommentNumber = "2 Comments",
                Likes = 2,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Poppy",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "Karl",
                        Message = "Buy my phone"
                    }
                }
            };
            postList.Add(post4);
            SocialPost post5 = new SocialPost
            {
                Name = "Koko",
                Message = "Stop bullying",
                CommentNumber = "1 Comments",
                Likes = 5,
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Poppy",
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
                Name = "Õpilane",
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