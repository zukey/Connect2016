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
    
    public partial class HintProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HintProvider()
        {
            this.ThemeImage = new HashSet<ThemeImage>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThemeImage> ThemeImage { get; set; }
    }
}