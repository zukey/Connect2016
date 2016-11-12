using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using System.IO;
using System.Threading.Tasks;

namespace PictureStampRally.WebApi.Models
{
    public static class BlobManager
    {
        const string FOLDER_THEME = "images";
        const string FOLDER_CAPTURED = "captured";

        public static BlobUpdateResult UploadThemeImage(byte[] data, int themeImageId, string originalBlobName = null)
        {
            return Upload(data, FOLDER_THEME, themeImageId, originalBlobName);
        }

        public static BlobUpdateResult UploadCapturedImage(byte[] data, int themeImageId, string originalBlobName = null)
        {
            return Upload(data, FOLDER_CAPTURED, themeImageId, originalBlobName);
        }

        private static BlobUpdateResult Upload(byte[] data, string folder, int themeImageId, string originalBlobName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("connect2016");

            // アップロード
            var blobName = CreateBlobName(folder, themeImageId);
            var blockBlob = container.GetBlockBlobReference(blobName);
            blockBlob.UploadFromByteArray(data, 0, data.Length);

            // オリジナルの削除
            if (!string.IsNullOrEmpty(originalBlobName))
            {
                var removeBlob = container.GetBlockBlobReference(originalBlobName);
                removeBlob.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots);
            }

            return new BlobUpdateResult() { Url = blockBlob.Uri.ToString(), BlobName = blobName };
        }

        public static byte[] DownloadThemeImage(string blobName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("connect2016");

            var blockBlob = container.GetBlockBlobReference(blobName);

            using (var ms = new MemoryStream())
            {
                blockBlob.DownloadToStream(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// BlobNameを生成します。
        /// </summary>
        /// <param name="folder">サブディレクトリ</param>
        /// <param name="themeImageId">お題のID</param>
        /// <returns></returns>
        private static string CreateBlobName(string folder, int themeImageId)
        {
            var r = new Random();
            return string.Format("{0}/{1}-{2}", folder, themeImageId, r.Next());
        }
    }
}