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

            Image = new BitmapImage(new Uri(source.ImageUrl));
        }

        public BitmapImage Image { get; private set; }
    }
}
