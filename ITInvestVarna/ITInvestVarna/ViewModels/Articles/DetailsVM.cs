using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITInvestVarna.ViewModels.Articles
{
    public class DetailsVM
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime? DateTimeModified { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Location { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public string ImgPath { get; set; }

        public User User { get; set; }

        public Category category { get; set; }

        public ICollection<KeyWord> KeyWords { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Gallery> Galleries { get; set; }

        public void PopulateDetailModel(Article item)
        {

            Title = item.Title;
            Text = item.Text;
            Type = item.Type;
            UserId = item.UserId;
            category = item.category;
            ImgPath = item.ImgPath;
            DateTime = item.DateTime;
            DateTimeModified = item.DateTimeModified;
            KeyWords = item.KeyWords;
        }
    }
}