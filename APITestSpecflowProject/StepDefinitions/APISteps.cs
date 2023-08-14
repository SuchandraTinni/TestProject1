using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestProject1.APITestProject.Hooks;
using System.Text.Json;
using RestSharp;
using static TestProject1.APITestProject.APIPageClass.ApiRequest;

namespace TestProject1.APITestProject.StepDefinitions;

[Binding]
public class APISteps : BaseClass
{
    [Given(@"I perform a get request (.*)")]
    public void GivenIPerformAGetRequest(string contextPath)
    {
        _response = GetRequest(contextPath);
        Console.WriteLine(_response);
    }

    [Then(@"assert get request status code (.*) for a successful response")]
    public void ThenAssertGetRequestStatusCodeForASuccessfulResponse(string statusCode)
    {
        Assert.Equals(statusCode, (int)_response.StatusCode);
        testObj1 = JObject.Parse(_response.Content);
    }

    [Then(@"assert get request (.*)")]
    public void ThenAssertGetRequest(string name)
    {
        var client = new RestClient("https://api.tmsandbox.co.nz/v1");
        var request = new RestRequest("Categories/6327/Details.json", Method.Get);
        request.AddParameter("catalogue", "false");
        var response = client.Execute<dynamic>(request);
        var responseContent = response.Content;
        using var document = JsonDocument.Parse(responseContent);
        Assert.AreEqual("Carbon credits", document.RootElement.GetProperty("Name").GetString());
    }

    [Then(@"assert value for (.*)")]
    public void ThenAssertValueFor(string canReList)
    {
        var client = new RestClient("https://api.tmsandbox.co.nz/v1");
        var request = new RestRequest("Categories/6327/Details.json", Method.Get);
        request.AddParameter("catalogue", "false");
        var response = client.Execute<dynamic>(request);
        var responseContent = response.Content;
        using var document = JsonDocument.Parse(responseContent);
        Assert.IsTrue(document.RootElement.GetProperty("CanRelist").GetBoolean());
    }

    [Then(@"assert Promotions is not null and has (.*) and has a (.*) containing text")]
    public void ThenAssertIsNotNullAndHasAnElementNameAndHasAContainingText(string PromotionsName, string Description)
    {
        var client = new RestClient("https://api.tmsandbox.co.nz/v1");
        var request = new RestRequest("Categories/6327/Details.json", Method.Get);
        request.AddParameter("catalogue", "false");
        var response = client.Execute<dynamic>(request);
        var responseContent = response.Content;
        using var document = JsonDocument.Parse(responseContent);
        var promotions = document.RootElement.GetProperty("Promotions");
        Assert.IsNotNull(promotions);
        Assert.IsTrue(promotions.GetArrayLength() > 0);
        Assert.IsNotNull(PromotionsName);
        PromotionsName.Contains(Description);
    }
}