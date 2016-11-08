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
    public class ThemeInfoController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IEnumerable<ThemeInfo> Get(int eventId)
        {
            _Logger.Info("ThemeInfo/Get");

            try
            {
                using (var db = new Connect2016TZEntities())
                {
                    var targets = db.ThemeImage.AsNoTracking().Where(x => x.EventId == eventId).Include(x => x.HintProvider).ToArray();

                    var ret = targets.Select(x => new ThemeInfo()
                    {
                        Id = x.Id,
                        HintAddress = x.HintAddr,
                        ImageBase64String = Convert.ToBase64String(x.Image),
                        Score = x.Score?.ScoreValue,
                        Hints = x.HintProvider.Select(h => h.Name).ToArray()
                    }).ToArray();

                    return ret;
                }
            }
            catch (Exception ex)
            {
                _Logger.Warn(ex, "例外");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
