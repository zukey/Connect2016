﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace PictureStampRally
{
    public partial interface IFileUploadSample
    {
        /// <param name='buffer'>
        /// Required. アップロードするファイル
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<string>> PostWithOperationResponseAsync(Stream buffer, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}