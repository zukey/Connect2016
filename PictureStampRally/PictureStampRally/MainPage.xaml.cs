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

using PictureStampRally.Views;
using PictureStampRally.Models;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace PictureStampRally
{
    /// <summary>
    /// メインページ
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// イベント1押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var para = new EventPageParameter() { EventId = 1, };
            Frame.Navigate(typeof(EventPage), para.ToJsonSerializeString());
        }

        /// <summary>
        /// イベント2押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var para = new EventPageParameter() { EventId = 2, };
            Frame.Navigate(typeof(EventPage), para.ToJsonSerializeString());
        }

        /// <summary>
        /// イベント3押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var para = new EventPageParameter() { EventId = 1, };
            Frame.Navigate(typeof(EventPage), para.ToJsonSerializeString());
        }
    }
}
