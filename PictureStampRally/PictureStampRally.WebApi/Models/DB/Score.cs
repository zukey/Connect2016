//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PictureStampRally.WebApi.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int ThemeImageId { get; set; }
        public int ScoreValue { get; set; }
        public string CaptureImageUrl { get; set; }
        public string BlobName { get; set; }
    
        public virtual ThemeImage ThemeImage { get; set; }
    }
}
