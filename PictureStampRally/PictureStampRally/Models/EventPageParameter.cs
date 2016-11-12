using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;

namespace PictureStampRally.Models
{
    public class EventPageParameter
    {
        /// <summary>
        /// シリアライズされた文字列からインスタンスを復元します。
        /// </summary>
        /// <param name="jsonSerializeString">シリアライズされた文字列</param>
        /// <returns></returns>
        public static EventPageParameter CreateFrom(string jsonSerializeString)
        {
            var serializer = new DataContractJsonSerializer(typeof(EventPageParameter));
            var bytes = Encoding.UTF8.GetBytes(jsonSerializeString);
            using (var ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return serializer.ReadObject(ms) as EventPageParameter;
            }
        }

        /// <summary>
        /// イベントIDを取得／設定します。
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// デフォルトで表示するお題のIDを取得／設定します。
        /// </summary>
        public int? DefaultThemeImageId { get; set; }

        /// <summary>
        /// シリアライズします。
        /// </summary>
        /// <returns></returns>
        public string ToJsonSerializeString()
        {
            var serializer = new DataContractJsonSerializer(typeof(EventPageParameter));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
