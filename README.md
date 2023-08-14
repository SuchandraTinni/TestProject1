TestProject1

This is a .NET C# project that tests an API using RestSharp and NUnit and also tests the same API with the help of Specflow framework.

Prerequisites

Visual Studio or Rider
RestSharp library
NUnit framework
Newtonsoft.Json library
System.Text.Json library
Specflow plugin for .NET

Installation
Clone the repository from GitHub.
Open the project in Visual Studio or Rider.
Install the RestSharp, Newtonsoft.Json,Specflow for .NET and System.Text.Json libraries using NuGet.
Build the project.

Usage- APITest
Open the ApiTests.cs file.
Run the TestApi method to send a GET request to the API and validate the response using the acceptance criteria.
The acceptance criteria are:
Name = "Carbon credits"
CanRelist = true
The Promotions element with Name = "Gallery" has a Description that contains the text "Good position in category"

Usage- APITestSpecflowProject
Open the Features folder.
Open the APITest.feature file which has the Test Scenario and test steps.This framework is called Behaviour driven development framework and also adds to the reusability of the project.
Run the @api tag to run the API test which will perform a GET Request and validate the acceptance criteria.
Underneath the Test Steps there are Step definition class in the Step definition folder. 