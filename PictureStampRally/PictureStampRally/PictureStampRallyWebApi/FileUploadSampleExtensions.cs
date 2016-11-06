﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using PictureStampRally;

namespace PictureStampRally
{
    public static partial class FileUploadSampleExtensions
    {
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IFileUploadSample.
        /// </param>
        /// <param name='buffer'>
        /// Required. アップロードするファイル
        /// </param>
        public static string Post(this IFileUploadSample operations, Stream buffer)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IFileUploadSample)s).PostAsync(buffer);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IFileUploadSample.
        /// </param>
        /// <param name='buffer'>
        /// Required. アップロードするファイル
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> PostAsync(this IFileUploadSample operations, Stream buffer, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.PostWithOperationResponseAsync(buffer, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
