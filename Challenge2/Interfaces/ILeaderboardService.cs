using Challenge2.Models;

namespace Challenge2.Interfaces
{
    //Interface for dependency Injection
    //Service used to add and retrieve leaderboard data
    public interface ILeaderboardService
    {
        public Boolean addEntries(List<Entry> e); //This method takes a list of entries and adds it to a datastore
        public LeaderboardModel getLeaderboardModel(int pageNum, int n); //creates a subset of leaderboard entries based on page number and number of entries n 
    }
}
