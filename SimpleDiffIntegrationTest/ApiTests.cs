using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDiff.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleDiffIntegrationTest
{
    [TestClass]
    public class ApiTests
    {
        private readonly HttpClient _httpClient;

        public ApiTests()
        {
            var webAppFactory = new CustomWebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task TestAddLeft()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/left", new DiffPostModel { Input = "Ales"});
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task TestAddRight()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/right", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task TestAddBoth()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/left", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var response2 = await _httpClient.PostAsJsonAsync("v1/diff/1/right", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task TestAddBothAndGetResult()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/left", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var response2 = await _httpClient.PostAsJsonAsync("v1/diff/1/right", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.OK);

            var response3 = await _httpClient.GetAsync("v1/diff/1");
            Assert.AreEqual(response3.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task TestNotFound()
        {
            var response = await _httpClient.GetAsync("v1/diff/1");
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task TestAdd2LeftWithSameId()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/left", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var response2 = await _httpClient.PostAsJsonAsync("v1/diff/1/left", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public async Task TestAdd2RightWithSameId()
        {
            var response = await _httpClient.PostAsJsonAsync("v1/diff/1/right", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var response2 = await _httpClient.PostAsJsonAsync("v1/diff/1/right", new DiffPostModel { Input = "Ales" });
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
    }
}