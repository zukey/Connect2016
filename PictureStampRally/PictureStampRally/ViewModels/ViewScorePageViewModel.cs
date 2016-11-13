using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
        /// 画面遷移時に渡されたパラメータを取得します。
        /// </summary>
        public ViewScorePageParameter Parameter { get; private set; }

        #region 初期化完了フラグ
        private bool _initialized;

        /// <summary>
        /// 初期化完了フラグを取得します。
        /// </summary>
        public bool Initialized
        {
            get { return _initialized; }
            private set
            {
                SetProperty(ref _initialized, value);
            }
        }
        #endregion

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

        #region 非同期待ち中フラグ
        private bool _awaiting;

        /// <summary>
        /// 非同期待ち中フラグを取得します。
        /// </summary>
        public bool Awaiting
        {
            get { return _awaiting; }
            private set
            {
                SetProperty(ref _awaiting, value);
            }
        }
        #endregion

        #region 状態メッセージ
        private string _stateMessage;

        /// <summary>
        /// 状態メッセージを取得します。
        /// </summary>
        public string StateMessage
        {
            get { return _stateMessage; }
            private set
            {
                SetProperty(ref _stateMessage, value);
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
            Parameter = param;

            // 計算中
            SetAwaiting("スコア計算中...");

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
                Initialized = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ScoreCheck例外");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                ClearAwaiting();
            }
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        public async Task Regist()
        {
            // 登録中
            SetAwaiting("スコア登録中...");

            try
            {
                // 撮影したファイルを取得
                var file = await StorageFile.GetFileFromPathAsync(Parameter.CaptureImageFilePath);

                using (var api = new PictureStampRallyWebApi())
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    // 登録処理
                    var result = await api.Score.RegistAsync(stream, Parameter.ThemeImageId);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("登録例外");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                ClearAwaiting();
            }
        }

        #region プライベートメソッド
        /// <summary>
        /// 非同期待ち中にセット
        /// </summary>
        /// <param name="message"></param>
        private void SetAwaiting(string message)
        {
            Awaiting = true;
            StateMessage = message;
        }

        /// <summary>
        /// 非同期待ち中解除
        /// </summary>
        private void ClearAwaiting()
        {
            Awaiting = false;
            StateMessage = "";
        }
        #endregion
    }
}
