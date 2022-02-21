using Microsoft.AspNetCore.Mvc;
using Challenge2.Interfaces;
using Challenge2.Models;
using System.Collections.Generic;


namespace Challenge2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {

        //private readonly ILogger<LeaderboardController> _logger;
        private ILeaderboardService _Leaderboard;

        public LeaderboardController(ILeaderboardService Leaderboard)
        {
            _Leaderboard = Leaderboard;
        }

        //[HttpGet] GET
        //public Entry getEntry()
        //{
        //    return _Leaderboard.getEntry();
//        }

       /* [HttpGet] //GET
        public List<Entry> getLeaderboard()
        {
            return _Leaderboard.getLeaderboard();
        }*/

        [HttpGet] //GET
        public LeaderboardModel getLeaderboardModel()
        {
            return _Leaderboard.getLeaderboardModel();
        }
    }
}

/*
Goals for 2 / 21 / 2022
- Send 1 entry object { username, score, index}
&store it
- Retrieve it with get function
- Send multiple entries into a list 
- Retrieve entire list 

*/