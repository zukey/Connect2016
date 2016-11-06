﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using PictureStampRally;

namespace PictureStampRally
{
    public static partial class PictureStampRallyWebApiExtensions
    {
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='value'>
        /// Required.
        /// </param>
        public static object Create(this IPictureStampRallyWebApi operations, string value)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPictureStampRallyWebApi)s).CreateAsync(value);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='value'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> CreateAsync(this IPictureStampRallyWebApi operations, string value, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.CreateWithOperationResponseAsync(value, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static object Delete(this IPictureStampRallyWebApi operations, int id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPictureStampRallyWebApi)s).DeleteAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> DeleteAsync(this IPictureStampRallyWebApi operations, int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.DeleteWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        public static IList<string> GetAll(this IPictureStampRallyWebApi operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPictureStampRallyWebApi)s).GetAllAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<string>> GetAllAsync(this IPictureStampRallyWebApi operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<string>> result = await operations.GetAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static string GetById(this IPictureStampRallyWebApi operations, int id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPictureStampRallyWebApi)s).GetByIdAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> GetByIdAsync(this IPictureStampRallyWebApi operations, int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.GetByIdWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='value'>
        /// Required.
        /// </param>
        public static object Update(this IPictureStampRallyWebApi operations, int id, string value)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPictureStampRallyWebApi)s).UpdateAsync(id, value);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PictureStampRally.IPictureStampRallyWebApi.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='value'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> UpdateAsync(this IPictureStampRallyWebApi operations, int id, string value, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.UpdateWithOperationResponseAsync(id, value, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
