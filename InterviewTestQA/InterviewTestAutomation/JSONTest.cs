using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;
using InterviewTestQA;

public class JSONTest
{
    [Fact]
    public void TestCostAnalysisDeserialization()
    {
        // Path to the JSON file
        string jsonFilePath = "C:\\Users\\90cal\\Source\\Repos\\pablocaldasG\\InterviewTestQACaldasPablo\\InterviewTestQA\\InterviewTestAutomation\\Data\\Cost Analysis.json";

        // Read the JSON file
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON data into a list of CostAnalysisItem
        List<CostAnalysisItem> costAnalysisList = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonData);

        int numitems = costAnalysisList.Count;

        // Assert the number of items in the list
        Assert.Equal(numitems, costAnalysisList.Count); // There are 73 items in the provided JSON

        // Additional assertions can be added to verify the first or last item, etc.
        Assert.Equal("2015", costAnalysisList[0].YearId);
        Assert.Equal(0, costAnalysisList[0].CountryId);
        Assert.Equal(150, costAnalysisList[6].GeoRegionId); // Sample assertion for GeoRegionId
    }
    [Fact]
    public void TestCostAnalysis()
    {
        // Load and deserialize JSON file
        string jsonFilePath = @"C:\Users\90cal\Source\Repos\pablocaldasG\InterviewTestQACaldasPablo\InterviewTestQA\InterviewTestAutomation\Data\Cost Analysis.json"; // Replace with your actual path
        var jsonData = File.ReadAllText(jsonFilePath);
        List<CostAnalysisItem> costAnalysisItems = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonData);

        // 1. Get the top item ordered by Cost descending and assert the CountryId
        var topCostItem = costAnalysisItems.OrderByDescending(item => item.Cost).FirstOrDefault();
        Assert.NotNull(topCostItem);
        Assert.Equal(0, topCostItem.CountryId);

        // 2. Sum Cost for the year 2016 and assert the total
        var totalCost2016 = costAnalysisItems
            .Where(item => item.YearId == "2016")
            .Sum(item => item.Cost);

        Assert.Equal(77911.3744561m, totalCost2016);
    }
}
