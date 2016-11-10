using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using NLog;
using PictureStampRally.WebApi.Models;
using System.Net.Http.Headers;
using PictureStampRally.WebApi.Models.DB;

namespace PictureStampRally.WebApi.Controllers
{
    public class EventsController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IEnumerable<EventInfo> Get()
        {
            _Logger.Info("Events/Get");

            try
            {
                using (var db = new Connect2016TZEntities())
                {
                    var targets = db.Event.AsNoTracking().ToArray();

                    var ret = targets.Select(x => new EventInfo()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BorderScore = x.BorderScore
                    }).ToArray();

                    return ret;
                }
            }
            catch (Exception ex)
            {
                _Logger.Info(ex, "例外");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
