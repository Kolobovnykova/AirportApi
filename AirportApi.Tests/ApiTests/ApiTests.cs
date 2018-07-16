using Newtonsoft.Json;
using NUnit.Framework;
using Shared.DTOs;
using static Shared.RequestHelpers.RequestHelper;

namespace AirportApi.Tests.ApiTests
{
    [TestFixture]
    public class ApiTests
    {
        private const string Url = @"http://localhost:52062/api/";

        [Test]
        public void Test()
        {
            // Arrange
            // Act
            var response = GetRequest(Url + "crews");
            var crew = JsonConvert.DeserializeObject<CrewDTO[]>(response);
            // Assert
            Assert.IsInstanceOf<CrewDTO[]>(crew);
        }
        
        [Test]
        public void Test2()
        {
            // Arrange
            var responseList = GetRequest(Url + "crews");
            var crewList = JsonConvert.DeserializeObject<CrewDTO[]>(responseList);
            var id = crewList[0].Id;
            
            // Act
            var response = GetRequest(Url + "crews/" + id);
            var crew = JsonConvert.DeserializeObject<CrewDTO>(response);
            
            // Assert
            Assert.IsInstanceOf<CrewDTO>(crew);
        }
    }
}
