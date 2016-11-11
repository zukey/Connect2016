using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PictureStampRally.Models
{
    public static class ScoreOperationRequestContentCreator
    {
        public static MultipartContent Create(Stream file, int themeImageId)
        {
            var fileContent = new StreamContent(file);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            fileContent.Headers.ContentDisposition.Name = "\"file\"";

            var idContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(themeImageId.ToString()));
            idContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            idContent.Headers.ContentDisposition.Name = "\"themeImageId\"";
            idContent.Headers.ContentDisposition.DispositionType = "form-data";

            var requestContent = new MultipartContent();
            requestContent.Add(fileContent);
            requestContent.Add(idContent);

            return requestContent;
        }
    }
}
