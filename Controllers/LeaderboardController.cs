using Microsoft.AspNetCore.Mvc;
using Challenge2.Interfaces;

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

        [HttpGet] //GET
        public string getLboard()
        {
            return _Leaderboard.getLeaderboard();
        }
        
    }
}