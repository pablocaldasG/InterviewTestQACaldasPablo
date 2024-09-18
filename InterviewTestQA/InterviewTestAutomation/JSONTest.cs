using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace InterviewTestQA
{
    public class JSONTest
    {
        // Test to check deserialization of Cost Analysis data
        [Fact]
        public void TestCostAnalysisDeserialization()
        {
            // Get the directory two levels above the current directory (as the file is not in C:\Users\90cal\source\repos\pablocaldasG\InterviewTestQACaldasPablo\InterviewTestQA\bin\Debug\net6.0\InterviewTestAutomation\Data\Cost Analysis.json)
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Combine the project directory with the relative path to the JSON file
            string jsonFilePath = Path.Combine(projectDirectory, "InterviewTestAutomation", "Data", "Cost Analysis.json");

            // Ensure that the file exists at the specified path
            Assert.True(File.Exists(jsonFilePath), $"File not found at {jsonFilePath}");


            // Read the JSON file into a string
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON data into a list of CostAnalysisItem objects
            List<CostAnalysisItem> costAnalysisList = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonData);

            // Assert that the correct number of items was deserialized
            Assert.Equal(53, costAnalysisList.Count); // Expecting 53 items as per the provided JSON

            // Assert specific fields in the first item and a sample item in the list
            Assert.Equal("2015", costAnalysisList[0].YearId);
            Assert.Equal(0, costAnalysisList[0].CountryId);
            Assert.Equal(150, costAnalysisList[6].GeoRegionId); // Example check on GeoRegionId
        }

        // Test to perform additional checks on the Cost Analysis data
        [Fact]
        public void TestCostAnalysis()
        {
            // Get the directory two levels above the current directory (as the file is not in C:\Users\90cal\source\repos\pablocaldasG\InterviewTestQACaldasPablo\InterviewTestQA\bin\Debug\net6.0\InterviewTestAutomation\Data\Cost Analysis.json)
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Combine the project directory with the relative path to the JSON file
            string jsonFilePath = Path.Combine(projectDirectory, "InterviewTestAutomation", "Data", "Cost Analysis.json");

            // Ensure that the file exists at the specified path
            Assert.True(File.Exists(jsonFilePath), $"File not found at {jsonFilePath}");


            // Load and deserialize the JSON file into a list of CostAnalysisItem objects
            string jsonData = File.ReadAllText(jsonFilePath);
            List<CostAnalysisItem> costAnalysisItems = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonData);

            // 1. Get the top item ordered by Cost in descending order and assert the CountryId
            var topCostItem = costAnalysisItems.OrderByDescending(item => item.Cost).FirstOrDefault();
            Assert.NotNull(topCostItem); // Ensure that there is at least one item
            Assert.Equal(0, topCostItem.CountryId); // Example check on CountryId for the highest cost item

            // 2. Calculate the total Cost for the year 2016 and assert the total
            var totalCost2016 = costAnalysisItems
                .Where(item => item.YearId == "2016")
                .Sum(item => item.Cost);

            // Assert that the total cost for the year 2016 matches the expected value
            Assert.Equal(77911.3744561m, totalCost2016);
        }
    }
}
