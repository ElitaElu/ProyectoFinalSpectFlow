using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProyectoFinalSpectFlow.Features
{
    [Binding]
    public class GetProductByCategory
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/", Method.Get);
        RestResponse response;

        [Given(@"I have a valid category  (.*)")]
        public void GivenIHaveAValidCategory(int p0)
        {
            request.AddHeader("accept", "*/*");
            request.AddQueryParameter("category", 7);
        }
        
        [When(@"I sent get products request")]
        public void WhenISentGetProductsRequest()
        {
            response = client.ExecuteGet(request);
        }
        
        [Then(@"I expected valid code ok response")]
        public void ThenIExpectedValidCodeOkResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
