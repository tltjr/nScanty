using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MongoDB.Bson;

namespace nScanty.Models
{
    public class Post
    {
        private static readonly Dictionary<int, string> Months = new Dictionary<int, string>();

        public Post()
        {
            Months.Add(1, "JAN");
            Months.Add(2, "FEB");
            Months.Add(3, "MAR");
            Months.Add(4, "APR");
            Months.Add(5, "MAY");
            Months.Add(6, "JUN");
            Months.Add(7, "JUL");
            Months.Add(8, "AUG");
            Months.Add(9, "SEP");
            Months.Add(10, "OCT");
            Months.Add(11, "NOV");
            Months.Add(12, "DEC");
        }

        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Month
        {
            get { return ConvertMonthToString(CreatedAt.Month); }
        }

        public int Day
        {
            get { return CreatedAt.Day; }
        }

        public string Url { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; } 
            set
            {
                _title = value;
                var lower = Title.ToLower();
                var spacesParsed = Regex.Replace(lower, @" ", "_");
                Slug = Regex.Replace(spacesParsed, @"[^a-z0-9_]", String.Empty);
            }
        }
        public IEnumerable<string> Tags { get; set; }
        public string TagsRaw { get; set; }
        private string _body;

        [DataType(DataType.MultilineText)]
        public string Body
        {
            get { return _body; } 
            set
            {
                _body = value;
                More = _body.Length >= 200;
                Summary = More ? _body.Substring(0, 200) : _body;
            }
        }

        public string Summary { get; set; }
        public bool More { get; set; }

        public string Slug { get; set; }
                
        private static string ConvertMonthToString(int month)
        {
            return Months[month];
        }
    }
}