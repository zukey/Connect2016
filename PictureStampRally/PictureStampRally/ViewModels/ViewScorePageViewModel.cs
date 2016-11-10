using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PictureStampRally.Models;
using System.IO;
using Windows.Storage;

namespace PictureStampRally.ViewModels
{
    public class ViewScorePageViewModel : NotificationBase
    {
        ViewScorePageParameter _param;

        private int? _score;
        public int? Score
        {
            get { return _score; }
            set
            {
                SetProperty(ref _score, value);
            }
        }


        public async Task Initialize(ViewScorePageParameter param)
        {
            _param = param;
            var f = await StorageFile.GetFileFromPathAsync(param.CaptureImageFilePath);

            using (var api = new PictureStampRallyWebApi())
            using (var stream = await f.OpenStreamForReadAsync())
            {
                var result = await api.Score.CheckAsync(stream, param.ThemeImageId);
                Score = result.Score;
            }
        }

        public async Task Regist()
        {
            var f = await StorageFile.GetFileFromPathAsync(_param.CaptureImageFilePath);

            using (var api = new PictureStampRallyWebApi())
            using (var stream = await f.OpenStreamForReadAsync())
            {
                var result = await api.Score.RegistAsync(stream, _param.ThemeImageId);
            }
        }

    }
}
