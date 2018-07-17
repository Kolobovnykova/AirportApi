using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using Shared.DTOs;
using static Shared.RequestHelpers.RequestHelper;

namespace AirportApi.Tests.ApiTests
{
    [TestFixture]
    public class ApiTests
    {
        private const string Url = @"http://localhost:52062/api/stewardesses/";

        [Test]
        public void GetAllStewardesses()
        {
            var response = GetRequest(Url);
            var st = JsonConvert.DeserializeObject<StewardessDTO[]>(response);
            Assert.IsInstanceOf<StewardessDTO[]>(st);
        }

        [Test]
        public void GetStewardessById()
        {
            var responseList = GetRequest(Url);
            var stList = JsonConvert.DeserializeObject<StewardessDTO[]>(responseList);
            var id = stList[0].Id;

            var response = GetRequest(Url + id);
            var st = JsonConvert.DeserializeObject<StewardessDTO>(response);

            Assert.IsInstanceOf<StewardessDTO>(st);
            Assert.IsNotNull(st.Id);
            Assert.IsNotNull(st.FirstName);
            Assert.IsNotNull(st.LastName);
        }

        [Test]
        public void PostStewardess()
        {
            var stewardess = new StewardessDTO
            {
                FirstName = "Kateryna",
                LastName = "Bila",
                DateOfBirth = new DateTime(1988, 4, 10),
                CrewId = 1
            };

            string output = JsonConvert.SerializeObject(stewardess);
            PostRequest(Url, output);
            var responseList = GetRequest(Url);
            var stList = JsonConvert.DeserializeObject<StewardessDTO[]>(responseList);
            var id = stList.Last().Id;

            var response = GetRequest(Url + id);
            var st = JsonConvert.DeserializeObject<StewardessDTO>(response);

            Assert.IsInstanceOf<StewardessDTO>(st);
            Assert.IsNotNull(st.Id);
            Assert.IsNotNull(st.FirstName);
            Assert.IsNotNull(st.LastName);

            DeleteRequest(Url + id);
        }

        [Test]
        public void PutStewardess()
        {
            var stewardessPost = new StewardessDTO { FirstName = "Kateryna", LastName = "Bila", DateOfBirth = new DateTime(1988, 4, 10), CrewId = 1};
            var stewardessPut = new StewardessDTO { FirstName = "Isabella", LastName = "Bila", DateOfBirth = new DateTime(1988, 4, 10), CrewId = 1};

            string output = JsonConvert.SerializeObject(stewardessPost);
            PostRequest(Url, output);

            var responseList = GetRequest(Url);
            var stList = JsonConvert.DeserializeObject<StewardessDTO[]>(responseList);
            var id = stList.Last().Id;

            output = JsonConvert.SerializeObject(stewardessPut);
            PutRequest(Url + id, output);

            var response = GetRequest(Url + id);
            var st = JsonConvert.DeserializeObject<StewardessDTO>(response);

            Assert.IsInstanceOf<StewardessDTO>(st);
            Assert.IsNotNull(st.Id);
            Assert.IsNotNull(st.FirstName);
            Assert.AreEqual("Isabella", st.FirstName);
            Assert.IsNotNull(st.LastName);
            
            DeleteRequest(Url + id);
        }

        [Test]
        public void DeleteStewardess()
        {
            int id;
            var responseList = GetRequest(Url);
            var stList = JsonConvert.DeserializeObject<StewardessDTO[]>(responseList);

            if (stList.Length > 0)
            {
                id = stList.Last().Id;
            }
            else
            {
                var stewardess = new StewardessDTO
                {
                    FirstName = "Kateryna",
                    LastName = "Bila",
                    DateOfBirth = new DateTime(1988, 4, 10),
                    CrewId = 1
                };

                string output = JsonConvert.SerializeObject(stewardess);
                PostRequest(Url, output);
                var response = GetRequest(Url);
                var list = JsonConvert.DeserializeObject<StewardessDTO[]>(response);
                id = list.Last().Id;
            }

            DeleteRequest(Url + id);

            Assert.Throws<WebException>(
                () => GetRequest(Url + id));
        }
    }
}