using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureStampRally.WebApi.Models
{
    public class BlobUpdateResult
    {
        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// BlockBlobName
        /// </summary>
        public string BlobName { get; set; }
    }
}