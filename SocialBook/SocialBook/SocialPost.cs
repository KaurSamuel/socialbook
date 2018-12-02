using Android.Graphics.Drawables;
using System.Collections.Generic;

namespace SocialBook
{
    public class SocialPost
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string CommentNumber { get; set; }
        public int Likes { get; set; }
        public Drawable Picture { get; set; }
        public List<CommentData> Comments { get; set; }
    }
}