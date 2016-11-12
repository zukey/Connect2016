using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PictureStampRally.Models;
using Windows.UI.Xaml.Media.Imaging;

namespace PictureStampRally.ViewModels
{
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
                SelectedCapturedImage = _selectedTheme?.CapturedImage;
                SelectedHintProvidors = _selectedTheme?.Hints;
                SelectedScore = _selectedTheme?.Score;
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
        /// 選択中のお題に対する撮影データを取得／設定します。
        /// </summary>
        public BitmapImage SelectedCapturedImage
        {
            get { return _selectedCapturedImage; }
            set
            {
                SetProperty(ref _selectedCapturedImage, value);
            }
        }
        #endregion

        private int? _selectedScore;
        public int? SelectedScore
        {
            get { return _selectedScore; }
            set
            {
                SetProperty(ref _selectedScore, value);
            }
        }

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


        private IEnumerable<string> _selectedHintProvidors;
        public IEnumerable<string> SelectedHintProvidors
        {
            get { return _selectedHintProvidors; }
            set
            {
                SetProperty(ref _selectedHintProvidors, value);
            }
        }

        private string _selectedHintAddress;
        public string SelectedHintAddress
        {
            get { return _selectedHintAddress; }
            set
            {
                SetProperty(ref _selectedHintAddress, value);
            }
        }

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
                if (ThemeList.Any())
                {
                    SelectedTheme = ThemeList.First();
                }
            }

            // 目標スコア転記
            BorderScore = EventInfo.BorderScore;

            // トータルスコア計算
            TotalScore = ThemeList.Sum(x => x.Score.GetValueOrDefault(0));
        }
    }
}
