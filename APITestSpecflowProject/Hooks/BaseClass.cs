using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;

namespace TestProject1.APITestProject.Hooks;

public class BaseClass
{
    protected static RestResponse? _response;
    protected static JObject testObj1;
    protected static JArray testObj;
}