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

using PictureStampRally.ViewModels;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace PictureStampRally.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SamplePage : Page
    {
        SamplePageViewModel _vm = new SamplePageViewModel();

        public SamplePage()
        {
            this.InitializeComponent();
            this.DataContext = _vm;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            await _vm.UpdateValue();
        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void buttoncamera_Click(object sender, RoutedEventArgs e)
        {
            await CameraAppManager.CameraCaptureAndNavigateScore(this, 2);
        }
    }
}
