using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using PictureStampRally.WebApi.Models;

namespace PictureStampRally.WebApi.Controllers
{
    public class ThemeImagesController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IEnumerable<ThemeItem> Get(int eventId)
        {
            _Logger.Info("ThemeImages/Get");

            // TODO: DBから取得
            return new[] 
            {
                new ThemeItem()
                {
                    Id = 1,
                    HintAddress = "郡山市大槻町",
                    Image = new byte[0],
                    Score = null,
                    Hints = new[] { "FCS", "どこぞ" }
                }
            };
            throw new NotImplementedException();
        }
    }
}
