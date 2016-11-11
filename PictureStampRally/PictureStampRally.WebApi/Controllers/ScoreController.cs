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
using PictureStampRally.WebApi.Models.DB;
using PictureStampRally.WebApi.Models.ImageApproximate;

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

                // アップロードされたファイルを取得
                var provider = await Request.Content.ReadAsMultipartAsync();
                var fileContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("file"));
                var buffer = await fileContent.ReadAsByteArrayAsync();

                // id取得
                var idContent = provider.Contents
                    .First(x => x.Headers.ContentDisposition.Name == JsonConvert.SerializeObject("themeImageId"));
                var id = await idContent.ReadAsStringAsync();
                var themeImageId = int.Parse(id);

                using (var db = new Connect2016TZEntities())
                {
                    var targetTheme = db.ThemeImage.FirstOrDefault(x => x.Id == themeImageId);
                    if (targetTheme == null)
                    {
                        // 無かったらNotFound
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    // お題のイメージを取得
                    var themeImage = BlobManager.DownloadThemeImage(themeImageId);

                    // 撮影画像をBlobに保存
                    var captureImageUrl = BlobManager.UploadCapturedImage(buffer, themeImageId);

                    // スコアレコード取得
                    var target = db.Score.FirstOrDefault(x => x.ThemeImageId == themeImageId);
                    if (target == null)
                    {
                        target = db.Score.Add(new Score() { ThemeImageId = themeImageId });
                    }

                    // スコア計算
                    var calc = new ScoreCalculator();
                    // TODO: 出来たらもどす
                    //target.ScoreValue = calc.CalcApproximateScore(themeImage, buffer);
                    // とりあえずランダム値
                    var r = new Random();
                    target.ScoreValue = r.Next(100);

                    // 撮影データのURLセット
                    target.CaptureImageUrl = captureImageUrl;

                    // DB登録
                    db.SaveChanges();

                    // 結果を返す
                    return new ScoreCheckResult() { ThemeImageId = themeImageId, Score = target.ScoreValue };
                }
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
