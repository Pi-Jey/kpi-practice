using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PizzaProject.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PizzaProject.Test
{
    public class CafeTests
    {
        private HttpClient _client;
        private WebApplicationFactory _factory;
        private const string RequestUrl = "/api/Client/Сafe";

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [Test]
        public async Task clientsController_GetById_ReturnsclientModel()
        {
            var httpResponse = await _client.GetAsync(RequestUrl + 1);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var cafe = JsonConvert.DeserializeObject<Onion.CafeContract.Cafe>(stringResponse);

            Assert.AreEqual(1, cafe.Id);
            Assert.AreEqual("Domino's", cafe.Name);
            Assert.AreEqual("09:00", cafe.OpenTime);
            Assert.AreEqual("00:00", cafe.CloseTime);
        }
        [Test]
        public async Task clientsController_Add_AddsclientToDatabase()
        {
            var cafe = new Onion.CafeContract.Cafe { Name = "Domino's", OpenTime = "09:00", CloseTime = "00:00" };
            var content = new StringContent(JsonConvert.SerializeObject(cafe), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(RequestUrl + 1, content);


            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var cafeInResponse = JsonConvert.DeserializeObject<Onion.CafeContract.Cafe>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<PizzaProjectContext>();
                var databasecafe = await context.Cafes.FindAsync(cafeInResponse.Id);
                Assert.AreEqual(databasecafe.Id, cafeInResponse.Id);
                Assert.AreEqual(databasecafe.Name, cafeInResponse.Name);
                Assert.AreEqual(databasecafe.OpenTime, cafeInResponse.OpenTime);
                Assert.AreEqual(databasecafe.CloseTime, cafeInResponse.CloseTime);
            }
        }
        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var cafeId = 1;
            var httpResponse = await _client.DeleteAsync(RequestUrl + cafeId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<PizzaProjectContext>();

                Assert.AreEqual(0, context.Cafes.Count());
            }
        }
    }
}
