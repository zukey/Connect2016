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
    public class EventsController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IEnumerable<EventInfo> Get()
        {
            _Logger.Info("Events/Get");

            // TODO: DBから取得
            return new[] 
            {
                new EventInfo() { Id = 1, Name = "郡山", BorderScore = 500 },
                new EventInfo() { Id = 2, Name = "会津", BorderScore = 600 },
            };
        }
    }
}
