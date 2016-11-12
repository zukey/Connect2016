using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenCvSharp;
using System.IO;
using System.Drawing;

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
            int i, sch = 0;
            float[] range_0 = { 0, 256 };
            float[][] ranges = { range_0 };
            double tmp, dist = 0;
            IplImage src_img1, src_img2;
            IplImage[] dst_img1 = new IplImage[4];
            IplImage[] dst_img2 = new IplImage[4];

            CvHistogram[] hist1 = new CvHistogram[4];
            CvHistogram hist2;

            double score1 = 0;

            // 画像を読み込む
            src_img1 = IplImage.FromImageData(image1, LoadMode.GrayScale);
            src_img2 = IplImage.FromImageData(image2, LoadMode.GrayScale);

            // 入力画像のチャンネル数分の画像領域を確保
            sch = src_img1.NChannels;
            for (i = 0; i < sch; i++)
            {
                dst_img1[i] = Cv.CreateImage(Cv.Size(src_img1.Width, src_img1.Height), src_img1.Depth, 1);
            }

            // ヒストグラム構造体を確保
            int[] nHisSize = new int[1];
            nHisSize[0] = 256;
            hist1[0] = Cv.CreateHist(nHisSize, HistogramFormat.Array, ranges, true);

            // 入力画像がマルチチャンネルの場合，画像をチャンネル毎に分割
            if (sch == 1)
            {
                Cv.Copy(src_img1, dst_img1[0]);
            }
            else
            {
                Cv.Split(src_img1, dst_img1[0], dst_img1[1], dst_img1[2], dst_img1[3]);
            }

            for (i = 0; i < sch; i++)
            {
                Cv.CalcHist(dst_img1[i], hist1[i], false);
                Cv.NormalizeHist(hist1[i], 10000);
                if (i < 3)
                {
                    Cv.CopyHist(hist1[i], ref hist1[i + 1]);
                }
            }

            Cv.ReleaseImage(src_img1);

            try
            {
                // 入力画像のチャンネル数分の画像領域を確保
                for (i = 0; i < sch; i++)
                {
                    dst_img2[i] = Cv.CreateImage(Cv.Size(src_img2.Width, src_img2.Height), src_img2.Depth, 1);
                }

                // ヒストグラム構造体を確保
                nHisSize[0] = 256;
                hist2 = Cv.CreateHist(nHisSize, HistogramFormat.Array, ranges, true);

                // 入力画像がマルチチャンネルの場合，画像をチャンネル毎に分割
                if (sch == 1)
                {
                    Cv.Copy(src_img2, dst_img2[0]);
                }
                else
                {
                    Cv.Split(src_img2, dst_img2[0], dst_img2[1], dst_img2[2], dst_img2[3]);
                }

                // ヒストグラムを計算，正規化して，距離を求める
                for (i = 0; i < sch; i++)
                {
                    Cv.CalcHist(dst_img2[i], hist2, false);
                    Cv.NormalizeHist(hist2, 10000);
                    tmp = Cv.CompareHist(hist1[i], hist2, HistogramComparison.Bhattacharyya);
                    dist += tmp * tmp;
                }
                dist = Math.Sqrt(dist);

                // distを点数風に計算
                // TODO:計算についてはもう少し考える
                score1 = Math.Floor(100 - (dist * 100));

                // dist=0.00に近いほど同じ画像となる
                Console.WriteLine("{0} => Distance={1:F3}", "撮影した写真", dist);
                Console.WriteLine("スコア：{0}点 / 100点", score1);

                Cv.ReleaseHist(hist2);
                Cv.ReleaseImage(src_img2);
            }
            catch (OpenCVException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }


            Cv.ReleaseHist(hist1[0]);
            Cv.ReleaseHist(hist1[1]);
            Cv.ReleaseHist(hist1[2]);
            Cv.ReleaseHist(hist1[3]);

            // スコアを返す
            return (int)score1;
        }
    }
}