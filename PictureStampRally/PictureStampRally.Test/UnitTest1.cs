using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PictureStampRally.WebApi.Models.ImageApproximate;

namespace PictureStampRally.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void スコア化テスト()
        {
            // TODO: 頑張ってスコア化
            var testTarget = new ScoreCalculator();

            var score = testTarget.CalcApproximateScore(new byte[0], new byte[0]);

            Console.WriteLine(score);
        }
    }
}
