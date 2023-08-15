using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Assert = NUnit.Framework.Assert;
using System.Text.Json;
using NuGet.Frameworks;
using Xunit.Abstractions;


namespace TestProject2.APITest;

[TestClass]
    
public class ApiTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ApiTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [TestMethod]
    public void TestApi()
    {
        // Create a new RestSharp client and request object
        var client = new RestClient("https://api.tmsandbox.co.nz/v1");
        var request = new RestRequest("Categories/6327/Details.json", Method.Get);
        
        // Add query parameter to the request
        request.AddParameter("catalogue", "false");

        // Execute the request and get the response content
        var response = client.Execute<dynamic>(request);
        var responseContent = response.Content;
        
        // Parse the JSON response content into a JsonDocument
        using var document = JsonDocument.Parse(responseContent);

        // Assert the response meets the acceptance criteria
        Assert.AreEqual("Carbon credits", document.RootElement.GetProperty("Name").GetString());
        Assert.IsTrue(document.RootElement.GetProperty("CanRelist").GetBoolean());
        var promotions = document.RootElement.GetProperty("Promotions");
        Assert.IsNotNull(promotions);
        Assert.IsTrue(promotions.GetArrayLength() > 0);
        var galleryPromotion = promotions.EnumerateArray().FirstOrDefault(p => p.GetProperty("Name").GetString() == "Gallery");
        Assert.IsNotNull(galleryPromotion);
        var description = galleryPromotion.GetProperty("Description").GetString();
        Assert.IsTrue(description.Contains("Good position in category"));
        _testOutputHelper.WriteLine(responseContent);
    }

    
}
