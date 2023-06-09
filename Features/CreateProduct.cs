using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ProyectoFinalSpectFlow.Features
{
    [Binding]
    public class CreateProduct
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request1 = new RestRequest("/api/authenticate", Method.Post);
        RestRequest request2 = new RestRequest("/api/product/", Method.Post);
        RestResponse response1;
        RestResponse response2;
        string token;

        [Given(@"I have valid parameters")]
        public void GivenIHaveValidParameters()
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

            request2.AddJsonBody(new
            {
                name = "Eliana",
                description = "Orange ",
                image = "purple-glasses.jpg",
                price = "19.99",
                categoryId = 7

            });
        }
        
        [When(@"I sent post  request")]
        public void WhenISentPostRequest()
        {
            response2 = client.Execute(request2);
        }
        
        [Then(@"I expected valid product added")]
        public void ThenIExpectedValidProductAdded()
        {
            var content2 = response2.Content;
            var jsonObject = JObject.Parse(content2);
            var result = jsonObject.SelectToken("name").ToString();
            Assert.That(result, Is.EqualTo("Eliana"), "product is not added");
        }
    }
}
