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
    public class PizzaTests
    {
        private HttpClient _client;
        private WebApplicationFactory _factory;
        private const string RequestUrl = "/api/Client/Сafe/Pizza/";

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
            var pizza = JsonConvert.DeserializeObject<Onion.PizzaContract.Pizza>(stringResponse);

            Assert.AreEqual(1, pizza.Id);
            Assert.AreEqual("Margaryta", pizza.Name);
            Assert.AreEqual(30, pizza.Size);
            Assert.AreEqual("Sous 'Domino's', Moccarella", pizza.Recipe);
        }
        [Test]
        public async Task clientsController_Add_AddsclientToDatabase()
        {
            var pizza = new Onion.PizzaContract.Pizza { Name = "ddqqfewfwwq", Size = 30 , Recipe = "fqwewefqw" };
            var content = new StringContent(JsonConvert.SerializeObject(pizza), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync($"/api/Client/Cafe/{1}/Pizza", content);


            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var pizzaInResponse = JsonConvert.DeserializeObject<Onion.PizzaContract.Pizza>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<PizzaProjectContext>();
                var databasepizza = await context.Pizzas.FindAsync(pizzaInResponse.Id);
                Assert.AreEqual(databasepizza.Id, pizzaInResponse.Id);
                Assert.AreEqual(databasepizza.Name, pizzaInResponse.Name);
                Assert.AreEqual(databasepizza.Size, pizzaInResponse.Size);
                Assert.AreEqual(databasepizza.Recipe, pizzaInResponse.Recipe);
            }
        }

        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var pizzaId = 1;
            var httpResponse = await _client.DeleteAsync("api/Pizza/" + pizzaId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<PizzaProjectContext>();

                Assert.AreEqual(0, context.Pizzas.Count());
            }
        }
    }
}
