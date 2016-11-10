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

            // byte→イメージ
            //Image img1 = ByteArrayToImage(image1);
            //Image img2 = ByteArrayToImage(image2);

            // イメージ保存
            //img1.Save("C:\\img1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //img2.Save("C:\\img2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            /**
             * 配列にpathを格納
             * args[0] → テンプレート画像パス
             * args[1] → 比較したい画像が格納されたフォルダ(複数画像格納OK)
             */
            string[] args = { @"D:\Temp\img1\ikaduti.jpg", @"D:\Temp\img2" };

            int i, sch = 0;
            float[] range_0 = { 0, 256 };
            float[][] ranges = { range_0 };
            double tmp, dist = 0;
            IplImage src_img1, src_img2;
            IplImage[] dst_img1 = new IplImage[4];
            IplImage[] dst_img2 = new IplImage[4];

            CvHistogram[] hist1 = new CvHistogram[4];
            CvHistogram hist2;

            // (1)二枚の画像を読み込む．チャンネル数が等しくない場合は，終了
            if (args.Count() < 2)
            {
                Console.WriteLine("Usage : TestHistgram <file> <folder>");
                return 0;
            }

            // args[1]に格納されているファイルをすべて取得する
            IEnumerable<string> tempFiles = Directory.EnumerateFiles(args[1], "*.jpg", SearchOption.TopDirectoryOnly);
            Dictionary<string, double> NCCPair = new Dictionary<string, double>();

            //(1)テンプレート画像を読み込む
            // TODO:ここで落ちることがある模様
            src_img1 = IplImage.FromFile(args[0], LoadMode.AnyDepth | LoadMode.AnyColor);

            // (2)入力画像のチャンネル数分の画像領域を確保
            sch = src_img1.NChannels;
            for (i = 0; i < sch; i++)
            {
                dst_img1[i] = Cv.CreateImage(Cv.Size(src_img1.Width, src_img1.Height), src_img1.Depth, 1);
            }

            // (3)ヒストグラム構造体を確保
            int[] nHisSize = new int[1];
            nHisSize[0] = 256;
            hist1[0] = Cv.CreateHist(nHisSize, HistogramFormat.Array, ranges, true);

            // (4)入力画像がマルチチャンネルの場合，画像をチャンネル毎に分割
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


            // TODO:テンプレートと撮影した写真の比較となるためここループにしなくてもよさげ
            foreach (string file in tempFiles)
            {
                try
                {
                    // 距離値初期化
                    dist = 0.0;

                    // 比較対象の画像を読み込む
                    src_img2 = IplImage.FromFile(file, LoadMode.AnyDepth | LoadMode.AnyColor);

                    // (2)入力画像のチャンネル数分の画像領域を確保
                    //sch = src_img1.NChannels;
                    for (i = 0; i < sch; i++)
                    {
                        dst_img2[i] = Cv.CreateImage(Cv.Size(src_img2.Width, src_img2.Height), src_img2.Depth, 1);
                    }

                    // (3)ヒストグラム構造体を確保
                    nHisSize[0] = 256;
                    hist2 = Cv.CreateHist(nHisSize, HistogramFormat.Array, ranges, true);

                    // (4)入力画像がマルチチャンネルの場合，画像をチャンネル毎に分割
                    if (sch == 1)
                    {
                        Cv.Copy(src_img2, dst_img2[0]);
                    }
                    else
                    {
                        Cv.Split(src_img2, dst_img2[0], dst_img2[1], dst_img2[2], dst_img2[3]);
                    }

                    // (5)ヒストグラムを計算，正規化して，距離を求める
                    for (i = 0; i < sch; i++)
                    {
                        Cv.CalcHist(dst_img2[i], hist2, false);
                        Cv.NormalizeHist(hist2, 10000);
                        tmp = Cv.CompareHist(hist1[i], hist2, HistogramComparison.Bhattacharyya);
                        dist += tmp * tmp;
                    }
                    dist = Math.Sqrt(dist);

                    // distを点数風に計算しなおしてみた。
                    double score1 = Math.Floor(100 - (dist * 100));

                    // (6)求めた距離を文字として画像に描画
                    // dist=0.00に近いほど同じ画像となるっぽい。
                    Console.WriteLine("{0} => Distance={1:F3}", file, dist);
                    Console.WriteLine("スコア：{0}点 / 100点", score1);

                    Cv.ReleaseHist(hist2);
                    Cv.ReleaseImage(src_img2);
                }
                catch (OpenCVException ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }
            }

            Cv.ReleaseHist(hist1[0]);
            Cv.ReleaseHist(hist1[1]);
            Cv.ReleaseHist(hist1[2]);
            Cv.ReleaseHist(hist1[3]);

            return 0;
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b)
        {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

    }
}