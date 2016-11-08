using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using NLog;
using PictureStampRally.WebApi.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using PictureStampRally.WebApi.Models.DB;

namespace PictureStampRally.WebApi.Controllers
{
    public class ThemeImageController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [SwaggerOperationFilter(typeof(ThemeImageRegistOparationFilter))]
        public async Task<IHttpActionResult> Post()
        {
            _Logger.Info("ThemeImage/Post");
            try
            {
                if (Request.Content.IsMimeMultipartContent() == false)
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var provider = await Request.Content.ReadAsMultipartAsync();
                var fileContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("file"));
                var buffer = await fileContent.ReadAsByteArrayAsync();

                var eventIdContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("eventId"));
                var eventIdString = await eventIdContent.ReadAsStringAsync();

                var hintAddrContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("hintAddr"));
                var hintAddr = await hintAddrContent.ReadAsStringAsync();

                using (var db = new Connect2016TZEntities())
                {
                    var item = new ThemeImage()
                    {
                        EventId = int.Parse(eventIdString),
                        HintAddr = hintAddr,
                        Image = buffer,
                    };

                    db.ThemeImage.Add(item);

                    db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _Logger.Warn(ex, "例外");
                throw;
            }
        }

        [HttpPut]
        [SwaggerOperationFilter(typeof(ThemeImageUpdateOparationFilter))]
        public async Task<IHttpActionResult> Put()
        {
            _Logger.Info("ThemeImage/Put");
            try
            {
                if (Request.Content.IsMimeMultipartContent() == false)
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var provider = await Request.Content.ReadAsMultipartAsync();
                var fileContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("file"));
                var buffer = await fileContent.ReadAsByteArrayAsync();

                var themeIdContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("themeImageId"));
                var themeIdString = await themeIdContent.ReadAsStringAsync();
                var themeId = int.Parse(themeIdString);

                var hintAddrContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("hintAddr"));
                var hintAddr = await hintAddrContent.ReadAsStringAsync();

                using (var db = new Connect2016TZEntities())
                {
                    var target = db.ThemeImage.FirstOrDefault(x => x.Id == themeId);
                    if (target == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    target.Image = buffer;
                    target.HintAddr = hintAddr;

                    db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _Logger.Warn(ex, "例外");
                throw;
            }
        }

    }
}
