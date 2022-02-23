using Microsoft.AspNetCore.Mvc;
using Challenge2.Interfaces;
using Challenge2.Models;

namespace Challenge2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {

        private ILeaderboardService _Leaderboard;
        private readonly IConfiguration _config;    //used to access config setting for n entries
        
        public LeaderboardController(ILeaderboardService Leaderboard, IConfiguration config)
        {
            _Leaderboard = Leaderboard;
            _config = config;
        }

        [HttpPost] // POST if a user wants to add entries themselves
        public IActionResult addEntry([FromBody] List<Entry> ent)
        {
            try
            {
               return Ok(_Leaderboard.addEntries(ent)); 
            }
              catch (Exception)
            {
                  return BadRequest();
            }
        }
        
        [HttpGet] //GET paginated results of leaderboard. Page Number defaults to 1st page, n entries defaults to -1 which can be overriden by setting
        public IActionResult getLeaderboardModel(int pageNum = 1, int n = -1) 
        {
            try
            {
                if (n < 1)  // if user inputs negative number or no number for the optional query parameter, read default setting listed in appsettings.json
                {
                    n = Int32.Parse(_config["NEntries"]);   //Converts string to int of the setting NEntries
                }
                if (pageNum < 1) // if user inputs negative number or 0, API will default to first page
                {
                    pageNum = 1;
                }
                return Ok(_Leaderboard.getLeaderboardModel(pageNum, n)); 
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}


/* Goals for 2 / 20 / 2022
- Setup WebAPI Y
- Controller and Model Class Y
- Get methods Y
- Set up dependency Injection Y

Goals for 2 / 21 / 2022
- Send 1 entry object { username, score, index} Y
&store it
- Retrieve it with get function Y
- Send multiple entries into a list Y 
- Retrieve entire list Y
- Begin Pagination Y
- Number of entries defined in appsettings.json Y
- Completed Pagination : https://localhost:7118/api/leaderboard?pageNum=1&n=2 Y

- Todo: cleanup dead code, comments, change variables, look into Redis implementation

Goals for 2 / 22 / 2022
- Refactor code Y
- Add comments & fill out readme Y
- Add functionality to read json file if LeaderboardModel has no entries Y
- Add setting for data filepath Y
- Learn redis + add redis comments Y
- Start unit testing 
*/