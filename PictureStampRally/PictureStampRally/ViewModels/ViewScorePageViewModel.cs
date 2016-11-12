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
    /// <summary>
    /// 撮影したデータの確認画面用のViewModel
    /// </summary>
    public class ViewScorePageViewModel : NotificationBase
    {
        /// <summary>
        /// 画面遷移時に渡されたパラメータ
        /// </summary>
        ViewScorePageParameter _param;

        #region スコア
        private int? _score;

        /// <summary>
        /// スコアを取得します。
        /// </summary>
        public int? Score
        {
            get { return _score; }
            private set
            {
                SetProperty(ref _score, value);
            }
        }
        #endregion


        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="param">画面遷移時パラメータ</param>
        /// <returns></returns>
        public async Task Initialize(ViewScorePageParameter param)
        {
            // パラメータ保存
            _param = param;

            try
            {
                // 撮影したファイルを取得
                var file = await StorageFile.GetFileFromPathAsync(param.CaptureImageFilePath);

                using (var api = new PictureStampRallyWebApi())
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    // チェック
                    var result = await api.Score.CheckAsync(stream, param.ThemeImageId);

                    // スコア更新
                    Score = result.Score;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ScoreCheck例外");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        public async Task Regist()
        {
            // 撮影したファイルを取得
            var file = await StorageFile.GetFileFromPathAsync(_param.CaptureImageFilePath);

            using (var api = new PictureStampRallyWebApi())
            using (var stream = await file.OpenStreamForReadAsync())
            {
                // 登録処理
                var result = await api.Score.RegistAsync(stream, _param.ThemeImageId);
            }
        }
    }
}
