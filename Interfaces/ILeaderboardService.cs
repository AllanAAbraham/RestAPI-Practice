using Challenge2.Models;
using System.Collections.Generic;

namespace Challenge2.Interfaces
{
    public interface ILeaderboardService
    {
        public Boolean addEntries(List<Entry> e);
        public LeaderboardModel getLeaderboardModel(int pageNum, int n);//, string data, int ydata);
    }
}
