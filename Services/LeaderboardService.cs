using Challenge2.Interfaces;
using Challenge2.Models;

namespace Challenge2.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        public Entry getLeaderboard()
        {
            Entry entry1 = new Entry();
            entry1.username = "test";
            entry1.score = 1;
            entry1.index = 1;

            return entry1; 
        }
    }
}
