using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PictureStampRally.Models
{
    public class ViewScorePageParameter
    {
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

        public int ThemeImageId { get; set; }
        public string CaptureImageFilePath { get; set; }

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
