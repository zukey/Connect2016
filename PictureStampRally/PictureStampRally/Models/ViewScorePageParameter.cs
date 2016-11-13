using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PictureStampRally.Models
{
    /// <summary>
    /// スコア表示ページのパラメータ
    /// </summary>
    public class ViewScorePageParameter
    {
        /// <summary>
        /// シリアライズされた文字列からインスタンスを生成します。
        /// </summary>
        /// <param name="jsonSerializeString">シリアライズされた文字列</param>
        /// <returns></returns>
        public static ViewScorePageParameter CreateFrom(string jsonSerializeString)
        {
            var serializer = new DataContractJsonSerializer(typeof(ViewScorePageParameter));
            var bytes = Encoding.UTF8.GetBytes(jsonSerializeString);
            using (var ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return serializer.ReadObject(ms) as ViewScorePageParameter;
            }
        }

        /// <summary>
        /// イベントID
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// お題のID
        /// </summary>
        public int ThemeImageId { get; set; }

        /// <summary>
        /// 撮影データのファイルパス
        /// </summary>
        public string CaptureImageFilePath { get; set; }

        /// <summary>
        /// 現在のインスタンスをJson形式でシリアライズします。
        /// </summary>
        /// <returns></returns>
        public string ToJsonSerializeString()
        {
            var serializer = new DataContractJsonSerializer(typeof(ViewScorePageParameter));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
