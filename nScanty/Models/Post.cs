using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace nScanty.Models
{
    public class Post
    {
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
        public string Body { get; set; }

        public string Slug { get; set; }
                
        private static string ConvertMonthToString(int month)
        {
            switch (month)
            {
                case 1:
                    return "JAN";
                case 2:
                    return "FEB";
                case 3:
                    return "MAR";
                case 4:
                    return "APR";
                case 5:
                    return "MAY";
                case 6:
                    return "JUN";
                case 7:
                    return "JUL";
                case 8:
                    return "AUG";
                case 9:
                    return "SEP";
                case 10:
                    return "OCT";
                case 11:
                    return "NOV";
                default:
                    return "DEC";
            } 
        }
    }
}