using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PictureStampRally.Models;

namespace PictureStampRally.ViewModels
{
    /// <summary>
    /// サンプル
    /// </summary>
    public class SamplePageViewModel : NotificationBase
    {
        int _val;
        public int Val
        {
            get { return _val; }
            set { SetProperty(ref _val, value); }
        }

        /// <summary>
        /// サンプル
        /// </summary>
        public string Hoge { get; set; }

        public async Task UpdateValue()
        {
            using (var client = new PictureStampRallyWebApi())
            {
                var result = await client.GetByIdWithOperationResponseAsync(0);
                System.Diagnostics.Debug.WriteLine(result.Response.StatusCode);
                if (result.Body != null)
                {
                    var s = result.Body.Replace("\"", "");
                    int v;
                    if (int.TryParse(s, out v))
                    {
                        Val = v;
                    }
                }
            }
        }
    }
}
