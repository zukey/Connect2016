using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using PictureStampRally.Models;

namespace PictureStampRally.ViewModels
{
    public class ThemeInfoViewItem : ThemeInfo
    {
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

        public BitmapImage ThemeImage { get; private set; }
        public BitmapImage CapturedImage { get; private set; }
    }
}
