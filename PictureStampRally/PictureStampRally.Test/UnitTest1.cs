using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PictureStampRally.WebApi.Models;
using PictureStampRally.WebApi.Models.ImageApproximate;


namespace PictureStampRally.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void スコア化テスト()
        {
            try
            {
                //　ローカルの画像のURL
                String url1 = "C:/Users/murata/Pictures/Test/test1.jpg";
                String url2 = "C:/Users/murata/Pictures/Test/test3.jpg";

                // 画像の取得
                WebClient wc = new WebClient();
                byte[] picture1 = wc.DownloadData(url1);

                byte[] picture2 = wc.DownloadData(url2);

                // スコアの取得
                var testTarget = new ScoreCalculator();
                var score = testTarget.CalcApproximateScore(picture1, picture2);

                Console.WriteLine(score);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
