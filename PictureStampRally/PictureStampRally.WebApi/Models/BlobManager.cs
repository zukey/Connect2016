using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

namespace PictureStampRally.WebApi.Models
{
    public static class BlobManager
    {
        public static string Upload(byte[] data, int eventId, int themeImageId)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("connect2016");

            var blobName = string.Format("images/{0}-{1}", eventId, themeImageId);
            var blockBlob = container.GetBlockBlobReference(blobName);

            blockBlob.UploadFromByteArray(data, 0, data.Length);

            return blockBlob.Uri.ToString();
        }
    }
}