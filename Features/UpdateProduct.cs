using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ProyectoFinalSpectFlow.Features
{
    [Binding]
    public class UpdateProduct
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request1 = new RestRequest("/api/authenticate", Method.Post);
        RestRequest request2 = new RestRequest("/api/product/{id}", Method.Put);
        RestResponse response1;
        RestResponse response2;
        string token;
        [Given(@"I have a valid Product Id (.*)")]
        public void GivenIHaveAValidProductId(int p0)
        {
            request1.AddJsonBody(new
            {
                username = "admin",
                password = "admin",

            });

            response1 = client.Execute(request1);
            var content1 = response1.Content;
            var jsonObject1 = JObject.Parse(content1);
            token = jsonObject1.SelectToken("token").ToString();



            request2.AddHeader("Authorization", "Bearer " + token);
            request2.AddHeader("accept", "*/*");
            request2.AddHeader("Content-Type", "application/json");
            request2.AddUrlSegment("id", p0);
            request2.AddJsonBody(new
            {
                name = "ElianaUpdated",
                description = "Purple ",
                image = "purple-glasses.jpg",
                price = "19.99",
                categoryId = 7

            });
        }
        
        [When(@"I sent put request")]
        public void WhenISentPutRequest()
        {
            response2 = client.Execute(request2);
        }
        
        [Then(@"I expected valid product updated")]
        public void ThenIExpectedValidProductUpdated()
        {
            var content2 = response2.Content;
            var jsonObject = JObject.Parse(content2);
            var result = jsonObject.SelectToken("name").ToString();
            Assert.That(result, Is.EqualTo("ElianaUpdated"), "product is not updated");
        }
    }
}
