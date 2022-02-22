using Challenge2.Models;

namespace Challenge2.Interfaces
{
    //Interface for dependency Injection
    public interface ILeaderboardService
    {
        public Boolean addEntries(List<Entry> e);
        public LeaderboardModel getLeaderboardModel(int pageNum, int n);
    }
}
