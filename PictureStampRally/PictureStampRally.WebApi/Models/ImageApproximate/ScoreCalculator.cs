using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureStampRally.WebApi.Models.ImageApproximate
{
    /// <summary>
    /// 画像の近似スコアを計算します。
    /// </summary>
    public class ScoreCalculator
    {
        /// <summary>
        /// 指定された画像データの近似スコアを計算します。
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        /// <returns>スコア</returns>
        public int CalcApproximateScore(byte[] image1, byte[] image2)
        {
            return 0;
        }
    }
}