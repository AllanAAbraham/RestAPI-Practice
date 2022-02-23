using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge2.Controllers;
using Challenge2.Interfaces;
using Challenge2.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Moq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Creating mock IConfiguration 
        private IConfiguration configuration;

        //Creating mock ILeaderboardService
        private Mock<ILeaderboardService> leaderboardService = new Mock<ILeaderboardService>();

        [TestInitialize]
        public void TestInit()
        {
           var inMemorySettings = new Dictionary<string, string>{
                {"NEntries", "5"},
                {"Datapath", "/TestData/leaderboard2.json"}
            };
            configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            LeaderboardModel page = new LeaderboardModel();
            Entry entry1 = new Entry("Allan", 1, 1);
            page.LeaderboardEntries.Add(entry1);
            page.count = 1;
            page.page = 1;

            leaderboardService.Setup(t => t.addEntries(It.IsAny<List<Entry>>())).Returns(true);
            leaderboardService.Setup(t => t.getLeaderboardModel(1, 2)).Returns(page);
        }
    

        [TestMethod]
        public void TestingControllerReturnsPage1with1Entry()
        {
            var controller = new LeaderboardController(leaderboardService.Object, configuration); 
            

        }
    }
}