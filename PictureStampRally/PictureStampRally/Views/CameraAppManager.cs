using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.IO;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

using PictureStampRally.Models;

namespace PictureStampRally.Views
{
    /// <summary>
    /// カメラアプリ管理
    /// </summary>
    static class CameraAppManager
    {
        /// <summary>
        /// カメラアプリを起動して写真を撮影します。
        /// </summary>
        /// <returns>撮影した写真のファイル</returns>
        public static async Task<StorageFile> CameraCapture()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Png;
            captureUI.PhotoSettings.CroppedAspectRatio = new Size(16, 9);
            captureUI.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.MediumXga;
            //captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            return await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
        }

        /// <summary>
        /// カメラアプリを起動して写真を撮影し、スコアページに遷移します。
        /// </summary>
        /// <param name="from">呼び出し元のページ</param>
        /// <param name="eventId">イベントID</param>
        /// <param name="themeImageId">お題のID</param>
        /// <returns></returns>
        public static async Task CameraCaptureAndNavigateScore(Page from, int eventId, int themeImageId)
        {
            var photo = await CameraCapture();
            if (photo == null) { return; }

            var param = new ViewScorePageParameter()
            {
                EventId = eventId,
                ThemeImageId = themeImageId,
                CaptureImageFilePath = photo.Path
            };

            // スコア表示画面に遷移
            from.Frame.Navigate(typeof(ViewScore), param.ToJsonSerializeString());
        }
    }
}
