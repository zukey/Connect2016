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

        public static string UploadThemeImage(byte[] data, int themeImageId)
        {
            return Upload(data, FOLDER_THEME, themeImageId);
        }

        public static string UploadCapturedImage(byte[] data, int themeImageId)
        {
            return Upload(data, FOLDER_CAPTURED, themeImageId);
        }

        private static string Upload(byte[] data, string folder, int themeImageId)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("connect2016");

            var blobName = CreateBlobName(folder, themeImageId);
            var blockBlob = container.GetBlockBlobReference(blobName);

            blockBlob.UploadFromByteArray(data, 0, data.Length);

            return blockBlob.Uri.ToString();
        }

        public static byte[] DownloadThemeImage(int themeImageId)
        {
            return Download(FOLDER_THEME, themeImageId);
        }

        private static byte[] Download(string folder, int themeImageId)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("connect2016");

            var blobName = CreateBlobName(folder, themeImageId);
            var blockBlob = container.GetBlockBlobReference(blobName);

            using (var ms = new MemoryStream())
            {
                blockBlob.DownloadToStream(ms);
                return ms.ToArray();
            }
        }

        private static string CreateBlobName(string folder, int themeImageId)
        {
            return string.Format("{0}/{1}", folder, themeImageId);
        }
    }
}