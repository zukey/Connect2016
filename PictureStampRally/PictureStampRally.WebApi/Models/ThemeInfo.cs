using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureStampRally.WebApi.Models
{
    public class ThemeInfo
    {
        public int Id { get; set; }
        public string HintAddress { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> Hints { get; set; }
        public int? Score { get; set; }
        public string CapturedImageUrl { get; set; }
    }
}