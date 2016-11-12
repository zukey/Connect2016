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
        EventPageViewModel _viewModel;

        public EventPage()
        {
            this.InitializeComponent();

            _viewModel = new EventPageViewModel();
            DataContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var paramString = e.Parameter as string;
            if (paramString == null) { return; }

            var param = EventPageParameter.CreateFrom(paramString);

            await _viewModel.LoadThemeList(param.EventId);

            if (param.DefaultThemeImageId.HasValue)
            {
                var defaultSelected = _viewModel.ThemeList.FirstOrDefault(x => x.Id == param.DefaultThemeImageId.Value);
                _viewModel.SelectedTheme = defaultSelected;
            }
        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedTheme == null) { return; }

            await CameraAppManager.CameraCaptureAndNavigateScore(this
                , _viewModel.EventInfo.Id.GetValueOrDefault(0)
                , _viewModel.SelectedTheme.Id.GetValueOrDefault(0));
        }
    }
}
