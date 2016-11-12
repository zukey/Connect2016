using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

using Windows.Media.Capture;
using Windows.Storage;


// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

using PictureStampRally.Models;
using PictureStampRally.ViewModels;

namespace PictureStampRally.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ViewScore : Page
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        ViewScorePageViewModel _viewModel;

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        public ViewScore()
        {
            this.InitializeComponent();
            _viewModel = new ViewScorePageViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// 画面遷移時
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var paramJsonString = e.Parameter as string;
            if (paramJsonString == null) { return; }

            // パラメータ型に戻す
            var param = ViewScorePageParameter.CreateFrom(paramJsonString);

            // 初期化
            await _viewModel.Initialize(param);

            // キャプチャした画像ファイルを表示
            var bi = new BitmapImage(new Uri(param.CaptureImageFilePath));
            image.Source = bi;
        }


        private void buttonhome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void buttonRePhotograph_Click(object sender, RoutedEventArgs e)
        {
            // カメラ撮影
            await CameraAppManager.CameraCaptureAndNavigateScore(this
                , _viewModel.Parameter.EventId
                , _viewModel.Parameter.ThemeImageId);
        }


        private async void buttonRegist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 登録
                await _viewModel.Regist();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("例外");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            // イベントページに遷移
            var para = new EventPageParameter()
            {
                EventId = _viewModel.Parameter.EventId,
                DefaultThemeImageId = _viewModel.Parameter.ThemeImageId
            };
            Frame.Navigate(typeof(EventPage), para.ToJsonSerializeString());
        }
    }
}
