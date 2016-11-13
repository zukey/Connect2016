using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PictureStampRally.Models;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http.Filters;

namespace PictureStampRally.ViewModels
{
    /// <summary>
    /// イベントページのViewModel
    /// </summary>
    public class EventPageViewModel : NotificationBase
    {
        #region お題データリスト
        IEnumerable<ThemeInfoViewItem> _themeList;

        /// <summary>
        /// お題データリストを取得します。
        /// </summary>
        public IEnumerable<ThemeInfoViewItem> ThemeList
        {
            get { return _themeList; }
            private set
            {
                SetProperty(ref _themeList, value);
            }
        }
        #endregion

        #region 選択中のお題データ
        ThemeInfoViewItem _selectedTheme;

        /// <summary>
        /// 選択中のお題データを取得／設定します。
        /// </summary>
        public ThemeInfoViewItem SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                SetProperty(ref _selectedTheme, value);

                // 選択されたテーマに関連するプロパティを更新
                SelectedCapturedImage = _selectedTheme?.CapturedImage;
                SelectedHintProvidors = _selectedTheme?.Hints;
                SelectedScore = _selectedTheme?.Score == null ? "-" : _selectedTheme.Score.ToString();
                SelectedHintAddress = _selectedTheme?.HintAddress;
            }
        }
        #endregion

        #region イベントデータ
        EventInfo _eventInfo;

        /// <summary>
        /// イベントデータを取得します。
        /// </summary>
        public EventInfo EventInfo
        {
            get { return _eventInfo; }
            private set
            {
                SetProperty(ref _eventInfo, value);
            }
        }
        #endregion

        #region 選択中のお題に対する撮影データ
        private BitmapImage _selectedCapturedImage;

        /// <summary>
        /// 選択中のお題に対する撮影データを取得します。
        /// </summary>
        public BitmapImage SelectedCapturedImage
        {
            get { return _selectedCapturedImage; }
            private set
            {
                SetProperty(ref _selectedCapturedImage, value);
            }
        }
        #endregion

        #region 選択中のお題に対する撮影データのスコア
        private string _selectedScore;

        /// <summary>
        /// 選択中のお題に対する撮影データのスコアを取得します。
        /// </summary>
        public string SelectedScore
        {
            get { return _selectedScore; }
            set
            {
                SetProperty(ref _selectedScore, value);
            }
        }
        #endregion

        #region 選択中のお題のヒント提供店リスト
        private IEnumerable<string> _selectedHintProvidors;

        /// <summary>
        /// 選択中のお題に対するヒント提供店のリストを取得します。
        /// </summary>
        public IEnumerable<string> SelectedHintProvidors
        {
            get { return _selectedHintProvidors; }
            private set
            {
                SetProperty(ref _selectedHintProvidors, value);
            }
        }
        #endregion

        #region 選択中のお題に対するヒント（住所）
        private string _selectedHintAddress;

        /// <summary>
        /// 選択中のお題に対するヒント（住所）を取得します。
        /// </summary>
        public string SelectedHintAddress
        {
            get { return _selectedHintAddress; }
            set
            {
                SetProperty(ref _selectedHintAddress, value);
            }
        }
        #endregion


        #region  トータルスコア
        private int? _totalScore;

        /// <summary>
        /// トータルスコアを取得／設定します。
        /// </summary>
        public int? TotalScore
        {
            get { return _totalScore; }
            set
            {
                SetProperty(ref _totalScore, value);
            }
        }
        #endregion

        #region クリアボーダースコア
        private int? _borderScore;

        /// <summary>
        /// クリアボーダースコアを取得／設定します。
        /// </summary>
        public int? BorderScore
        {
            get { return _borderScore; }
            set
            {
                SetProperty(ref _borderScore, value);
            }
        }
        #endregion


        /// <summary>
        /// 指定されたイベントIDに関連する情報を取得してプロパティを更新します。
        /// </summary>
        /// <param name="eventId">イベントID</param>
        /// <returns></returns>
        public async Task LoadThemeList(int eventId)
        {
            using (var api = new PictureStampRallyWebApi())
            {
                // イベント情報を取得
                var events = await api.Events.GetAsync();
                EventInfo = events.FirstOrDefault(x => x.Id == eventId);

                // お題リストを取得
                var items = await api.ThemeInfo.GetAsync(eventId);
                ThemeList = items.Select(x => new ThemeInfoViewItem(x)).ToArray();
            }

            // 目標スコア転記
            BorderScore = EventInfo.BorderScore;

            // トータルスコア計算
            TotalScore = ThemeList.Sum(x => x.Score.GetValueOrDefault(0));
        }
    }
}
