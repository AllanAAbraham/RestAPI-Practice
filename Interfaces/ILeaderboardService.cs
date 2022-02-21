using Challenge2.Models;
using System.Collections.Generic;

namespace Challenge2.Interfaces
{
    public interface ILeaderboardService
    {
        public Entry getEntry();
        public List<Entry> getLeaderboard();
    }
}
