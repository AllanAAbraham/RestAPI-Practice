using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge2.Controllers;
using Challenge2.Interfaces;
using Challenge2.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;

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
            //creating appsettings.json
            var inMemorySettings = new Dictionary<string, string>{
                {"NEntries", "5"},
                {"Datapath", "/TestData/leaderboard2.json"}
            };
            configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
            //adding dummy entry 
            LeaderboardModel page = new LeaderboardModel();
            Entry entry1 = new Entry("Allan", 1, 1);
            page.LeaderboardEntries.Add(entry1);
            page.count = 1;
            page.page = 1;
            List<Entry> entries = new List<Entry>();
            //adding dummy entry
            //  leaderboardService.Setup(t => t.addEntries(It.IsAny<List<Entry>>()));
            leaderboardService.Setup(t => t.addEntries(entries));
            leaderboardService.Setup(t => t.addEntries(null)).Throws(new InvalidOperationException("Data File could not be read"));
            leaderboardService.Setup(t => t.getLeaderboardModel(1, 2)).Returns(page);
            leaderboardService.Setup(t => t.getLeaderboardModel(100, 2)).Throws(new InvalidOperationException("No more entries to display"));
        }


        [TestMethod]
        public void TestingControllerGETReturnsPage1with1Entry()
        {
            //setting up controller
            var controller = new LeaderboardController(leaderboardService.Object, configuration);
            //Running GET
            IActionResult actionResult = controller.getLeaderboardModel();

            //Validating GET returns correct status code
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));

        }

        [TestMethod]
        public void TestingControllerGETReturnsErrorWhenNoMoreEntriesAvailable()
        {
            //setting up controller
            var controller = new LeaderboardController(leaderboardService.Object, configuration);
            //Running GET
            IActionResult actionResult = controller.getLeaderboardModel(pageNum: 100, n: 2);

            //Validating GET returns correct status code
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void TestingControllerPOST1EntryReturnsOk()
        {
            //setting up controller
            var controller = new LeaderboardController(leaderboardService.Object, configuration);
            //Creating input
            List<Entry> ent = new List<Entry>();
            ent.Add(new Entry("Josh", 2, 3));
            //Running POST
            IActionResult actionResult = controller.addEntry(ent) ;
                
            //Validating POST returns correct status code
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TestingControllerPOSTMultipleEntryReturnsOk()
        {
            //setting up controller
            var controller = new LeaderboardController(leaderboardService.Object, configuration);
            //Creating multiple inputs
            List<Entry> ent = new List<Entry>();
            ent.Add(new Entry("Josh", 2, 3));
            ent.Add(new Entry("Farrin", 4, 3));
            ent.Add(new Entry("Dev", 2, 3));
            //Running POST
            IActionResult actionResult = controller.addEntry(ent);

            //Validating POST returns correct status code
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TestingControllerPOSTReturnsErrorWhenNoEntryIsProvided()
        {
            //setting up controller
            var controller = new LeaderboardController(leaderboardService.Object, configuration);
            //Creating multiple inputs
            List<Entry> ent = new List<Entry>();
            
            //Running POST
            IActionResult actionResult = controller.addEntry(ent);

            //Validating POST returns correct status code
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}