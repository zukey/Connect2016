using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using PictureStampRally.Models;

namespace PictureStampRally.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ThemeInfoViewItem : ThemeInfo
    {
        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="source">オリジナル</param>
        public ThemeInfoViewItem(ThemeInfo source)
        {
            Id = source.Id;
            HintAddress = source.HintAddress;
            Score = source.Score;
            Hints = source.Hints;
            ImageUrl = source.ImageUrl;
            CapturedImageUrl = source.CapturedImageUrl;

            ThemeImage = new BitmapImage(new Uri(source.ImageUrl));
            if (source.CapturedImageUrl != null)
            {
                CapturedImage = new BitmapImage(new Uri(source.CapturedImageUrl));
            }
        }

        /// <summary>
        /// お題のイメージデータを取得します。
        /// </summary>
        public BitmapImage ThemeImage { get; private set; }

        /// <summary>
        /// 撮影した写真のイメージデータを取得します。
        /// </summary>
        public BitmapImage CapturedImage { get; private set; }
    }
}
