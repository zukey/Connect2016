using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using PictureStampRally.WebApi.Models;
using Swashbuckle.Swagger.Annotations;
using NLog;

namespace PictureStampRally.WebApi.Controllers
{
    public class ScoreController : ApiController
    {
        static Logger _Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [SwaggerOperationFilter(typeof(ScoreOperationFilter))]
        public async Task<ScoreCheckResult> Check()
        {
            _Logger.Info("Score/Check");

            try
            {
                if (Request.Content.IsMimeMultipartContent() == false)
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                // TODO: ID有無判定

                // アップロードされたファイルを取得
                var provider = await Request.Content.ReadAsMultipartAsync();
                var fileContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("file"));
                var buffer = await fileContent.ReadAsByteArrayAsync();

                // id取得
                var idContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("themeImageId"));
                var id = await idContent.ReadAsStringAsync();

                // TODO: スコア計算して返す
                return new ScoreCheckResult() { Score = 0 };
            }
            catch (Exception ex)
            {
                Debug.Print("例外");
                Debug.Print(ex.ToString());
                throw;
            }
        }

        [HttpPost]
        [SwaggerOperationFilter(typeof(ScoreOperationFilter))]
        public async Task<ScoreCheckResult> Regist()
        {
            _Logger.Info("Score/Regist");

            try
            {
                if (Request.Content.IsMimeMultipartContent() == false)
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                // TODO: ID有無判定

                // アップロードされたファイルを取得
                var provider = await Request.Content.ReadAsMultipartAsync();
                var fileContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("file"));
                var buffer = await fileContent.ReadAsByteArrayAsync();

                // id取得
                var idContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("themeImageId"));
                var id = await idContent.ReadAsStringAsync();

                // TODO: スコア計算して登録
                return new ScoreCheckResult() { Score = 0 };
            }
            catch (Exception ex)
            {
                Debug.Print("例外");
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
