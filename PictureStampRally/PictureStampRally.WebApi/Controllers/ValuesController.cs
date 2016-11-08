using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using PictureStampRally.WebApi.Models.DB;
using NLog;

namespace PictureStampRally.WebApi.Controllers
{
    /// <summary>
    /// サンプルです。後で消す
    /// </summary>
    public class ValuesController : ApiController
    {
        Logger _Logger = LogManager.GetCurrentClassLogger();

        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            using (var db = new Connect2016TZEntities())
            {
                var items = db.Event.AsNoTracking().ToArray();
                foreach (var item in items)
                {
                    _Logger.Info("Event Id[{0}] Name[{1}] BorderScore[{2}]"
                        , item.Id, item.Name, item.BorderScore);
                }
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        public string Get(int id)
        {
            var r = new Random();
            return r.Next().ToString();
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
        }
    }
}
