﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using PictureStampRally;
using PictureStampRally.Models;

namespace PictureStampRally
{
    public partial class PictureStampRallyWebApi : ServiceClient<PictureStampRallyWebApi>, IPictureStampRallyWebApi
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IEvents _events;
        
        public virtual IEvents Events
        {
            get { return this._events; }
        }
        
        private IFileUploadSample _fileUploadSample;
        
        public virtual IFileUploadSample FileUploadSample
        {
            get { return this._fileUploadSample; }
        }
        
        private IScore _score;
        
        public virtual IScore Score
        {
            get { return this._score; }
        }
        
        private IThemeImage _themeImage;
        
        public virtual IThemeImage ThemeImage
        {
            get { return this._themeImage; }
        }
        
        private IThemeInfoOperations _themeInfo;
        
        public virtual IThemeInfoOperations ThemeInfo
        {
            get { return this._themeInfo; }
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        public PictureStampRallyWebApi()
            : base()
        {
            this._events = new Events(this);
            this._fileUploadSample = new FileUploadSample(this);
            this._score = new Score(this);
            this._themeImage = new ThemeImage(this);
            this._themeInfo = new ThemeInfoOperations(this);
            this._baseUri = new Uri("https://picturestamprallywebapi.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public PictureStampRallyWebApi(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._events = new Events(this);
            this._fileUploadSample = new FileUploadSample(this);
            this._score = new Score(this);
            this._themeImage = new ThemeImage(this);
            this._themeInfo = new ThemeInfoOperations(this);
            this._baseUri = new Uri("https://picturestamprallywebapi.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public PictureStampRallyWebApi(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._events = new Events(this);
            this._fileUploadSample = new FileUploadSample(this);
            this._score = new Score(this);
            this._themeImage = new ThemeImage(this);
            this._themeInfo = new ThemeInfoOperations(this);
            this._baseUri = new Uri("https://picturestamprallywebapi.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public PictureStampRallyWebApi(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public PictureStampRallyWebApi(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureStampRallyWebApi class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public PictureStampRallyWebApi(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <param name='value'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<object>> CreateWithOperationResponseAsync(string value, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("value", value);
                ServiceClientTracing.Enter(invocationId, this, "CreateAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/api/Values";
            string baseUrl = this.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Headers
            
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Serialize Request
            string requestContent = null;
            JToken requestDoc = new JValue(value);
            requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.NoContent)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<object> result = new HttpOperationResponse<object>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            object resultModel = default(object);
            result.Body = resultModel;
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<object>> DeleteWithOperationResponseAsync(int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("id", id);
                ServiceClientTracing.Enter(invocationId, this, "DeleteAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/api/Values/";
            url = url + Uri.EscapeDataString(id.ToString());
            string baseUrl = this.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Delete;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.NoContent && statusCode != HttpStatusCode.NotFound)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<object> result = new HttpOperationResponse<object>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            object resultModel = default(object);
            result.Body = resultModel;
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IList<string>>> GetAllWithOperationResponseAsync(CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                ServiceClientTracing.Enter(invocationId, this, "GetAllAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/api/Values";
            string baseUrl = this.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<IList<string>> result = new HttpOperationResponse<IList<string>>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                IList<string> resultModel = new List<string>();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = StringCollection.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<string>> GetByIdWithOperationResponseAsync(int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("id", id);
                ServiceClientTracing.Enter(invocationId, this, "GetByIdAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/api/Values/";
            url = url + Uri.EscapeDataString(id.ToString());
            string baseUrl = this.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<string> result = new HttpOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                string resultModel = default(string);
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = responseDoc.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='value'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<object>> UpdateWithOperationResponseAsync(int id, string value, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("id", id);
                tracingParameters.Add("value", value);
                ServiceClientTracing.Enter(invocationId, this, "UpdateAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/api/Values/";
            url = url + Uri.EscapeDataString(id.ToString());
            string baseUrl = this.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Put;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Headers
            
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Serialize Request
            string requestContent = null;
            JToken requestDoc = new JValue(value);
            requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.NoContent && statusCode != HttpStatusCode.NotFound)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<object> result = new HttpOperationResponse<object>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            object resultModel = default(object);
            result.Body = resultModel;
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
    }
}
