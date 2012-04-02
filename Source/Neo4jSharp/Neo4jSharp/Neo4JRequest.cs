using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Neo4jSharp
{
    public abstract class Neo4JRequest
    {
        protected Neo4JRequest(string url, string method)
        {
            this.url = url;
            this.method = method;
        }

        public void Serialize(Stream stream)
        {
            using (TextWriter writer = new StreamWriter(stream))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, this);
            }
        }

        public HttpWebRequest CreateRequest(string server)
        {
            var request = HttpWebRequest.Create(server + url) as HttpWebRequest;
            request.Method = method;
            var requestStream = request.GetRequestStream();
            Serialize(requestStream);
            return request;

        }

        public IAsyncResult BeginCreateRequest(string server, AsyncCallback callback, object state)
        {
            GenericAsyncResult<HttpWebRequest> asyncResult = new GenericAsyncResult<HttpWebRequest>(state, callback);

            var request = HttpWebRequest.Create(server + url) as HttpWebRequest;
            request.Method = method;
            asyncResult.Data = request;

            Task<Stream> task = Task<Stream>.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, TaskCreationOptions.AttachedToParent);
            task.ContinueWith(k=> {
                Serialize(k.Result);
                asyncResult.Finished();
            });


            return asyncResult;
        }

        public HttpWebRequest EndCreateRequest(IAsyncResult result)
        {
            var resultContainer = result as GenericAsyncResult<HttpWebRequest>;
            return resultContainer.Data;
        }

        

        private string url;
        private string method;
    }
}
