using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using PictureStampRally.WebApi.Models;
using System.Net.Http.Headers;

namespace PictureStampRally.WebApi.Controllers
{
    public class ThemeInfoController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IEnumerable<ThemeInfo> Get(int eventId)
        {
            _Logger.Info("ThemeInfo/Get");

            // TODO: DBから取得
            return new[]
            {
                new ThemeInfo()
                {
                    Id = 1,
                    HintAddress = "郡山市大槻町",
                    Score = null,
                    Hints = new[] { "FCS", "どこぞ" }
                }
            };
        }
    }
}
