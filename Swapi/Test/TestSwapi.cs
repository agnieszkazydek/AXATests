using NUnit.Framework;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AxaSwapi
{
    [TestFixture]
    public class TestSwapi
    {
        [Test]
        public async Task Swapi()
        {
            using (var httpClient = new HttpClient())
            {
                var people = await httpClient.GetAsync("https://swapi.dev/api/people/1/");
                var jsonPeople = await people.Content.ReadAsStringAsync();
                var peopleObject = JsonDocument.Parse(jsonPeople);
                var name = peopleObject.RootElement.GetProperty("name").ToString();
                var homeworld = peopleObject.RootElement.GetProperty("homeworld").ToString();


                Assert.AreEqual("Luke Skywalker", name);
                Assert.AreEqual("https://swapi.dev/api/planets/1/", homeworld);


                var planet = await httpClient.GetAsync("https://swapi.dev/api/planets/1/");
                var jsonPlanet = await planet.Content.ReadAsStringAsync();
                var planetObject = JsonDocument.Parse(jsonPlanet);
                var planetName = planetObject.RootElement.GetProperty("name").ToString();

                Assert.AreEqual("Tatooine", planetName);
            }
        }
    }
}
