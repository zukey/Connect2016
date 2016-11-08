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
        public IEnumerable<string> Hints { get; set; }
        public int? Score { get; set; }
    }
}