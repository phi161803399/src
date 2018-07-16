using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;

namespace RekenMachineAPI.Tests.Component.Helpers
{
    public static class TestServerExtensions
    {
        public static async Task<TestServerResponseWithData<TOut>> GetAsJson<TOut>(this TestServer testServer,
            string path)
        {
            var request = testServer.CreateRequest(path);
            var response = await request.GetAsync();
            var data = await Deserialize<TOut>(response.Content);

            return new TestServerResponseWithData<TOut> {Data = data, HttpResponseMessage = response};
        }

        public static async Task<TestServerResponse> PostJson<TIn>(this TestServer testServer, string path, TIn obj)
        {
            var request = testServer.CreateRequest(path)
                .And(message => message.Content = new ObjectContent(typeof(TIn), obj, new JsonMediaTypeFormatter()));

            var response = await request.PostAsync();

            return new TestServerResponse {HttpResponseMessage = response};
        }

        public static async Task<TestServerResponseWithData<TOut>> PostJson<TIn, TOut>(this TestServer testServer,
            string path, TIn obj)
        {
            var request = testServer.CreateRequest(path)
                .And(message => message.Content = new ObjectContent(typeof(TIn), obj, new JsonMediaTypeFormatter()));

            var response = await request.PostAsync();
            var data = await Deserialize<TOut>(response.Content);

            return new TestServerResponseWithData<TOut> {Data = data, HttpResponseMessage = response};
        }

        public static async Task<TestServerResponse> PutJson<TIn>(this TestServer testServer, string path, TIn obj)
        {
            var request = testServer.CreateRequest(path)
                .And(message => message.Content = new ObjectContent(typeof(TIn), obj, new JsonMediaTypeFormatter()));

            var response = await request.SendAsync(HttpMethod.Put.Method);

            return new TestServerResponse {HttpResponseMessage = response};
        }

        public static async Task<TestServerResponseWithData<TOut>> PutJson<TIn, TOut>(this TestServer testServer,
            string path, TIn obj)
        {
            var request = testServer.CreateRequest(path)
                .And(message => message.Content = new ObjectContent(typeof(TIn), obj, new JsonMediaTypeFormatter()));

            var response = await request.SendAsync(HttpMethod.Put.Method);

            var data = await Deserialize<TOut>(response.Content);

            return new TestServerResponseWithData<TOut> {Data = data, HttpResponseMessage = response};
        }


        public static async Task<TestServerResponse> Delete(this TestServer testServer, string path)
        {
            var request = testServer.CreateRequest(path);
            var response = await request.SendAsync(HttpMethod.Delete.Method);
            return new TestServerResponse {HttpResponseMessage = response};
        }

        private static async Task<TOut> Deserialize<TOut>(HttpContent content)
        {
            var data = default(TOut);
            if (content != null)
            {
                var body = await content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<TOut>(body);
            }
            return data;
        }
    }

    public class TestServerResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }

    public class TestServerResponseWithData<T> : TestServerResponse
    {
        public T Data { get; set; }
    }
}