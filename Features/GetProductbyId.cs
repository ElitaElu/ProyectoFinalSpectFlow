using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace ProyectoFinalSpectFlow.Features
{
    [Binding]
    public class GetProductbyId
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/{id}", Method.Get);
        RestResponse response;

        [Given(@"I have a valid Id (.*)")]
        public void GivenIHaveAValidId(int p0)
        {
            request.AddUrlSegment("id", p0);
            request.AddHeader("accept", "*/*");
        }
        
        [When(@"I sent get request")]
        public void WhenISentGetRequest()
        {
            response = client.ExecuteGet(request);
        }
        
        [Then(@"I expected valid code response")]
        public void ThenIExpectedValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
