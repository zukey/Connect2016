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
    public sealed partial class EventPage : Page
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        EventPageViewModel _viewModel;

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        public EventPage()
        {
            this.InitializeComponent();

            _viewModel = new EventPageViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// 画面遷移時
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 呼び出しパラメータを復元
            var paramString = e.Parameter as string;
            if (paramString == null) { return; }

            var param = EventPageParameter.CreateFrom(paramString);

            // 表示データ取得
            await _viewModel.LoadThemeList(param.EventId);

            // デフォルトのお題IDが指定されている場合はそいつを表示
            if (param.DefaultThemeImageId.HasValue)
            {
                var defaultSelected = _viewModel.ThemeList.FirstOrDefault(x => x.Id == param.DefaultThemeImageId.Value);
                _viewModel.SelectedTheme = defaultSelected;
            }
        }

        /// <summary>
        /// 戻る押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// 撮影押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedTheme == null) { return; }

            await CameraAppManager.CameraCaptureAndNavigateScore(this
                , _viewModel.EventInfo.Id.GetValueOrDefault(0)
                , _viewModel.SelectedTheme.Id.GetValueOrDefault(0));
        }
    }
}
