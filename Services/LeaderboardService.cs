using Challenge2.Interfaces;
using Challenge2.Models;
using System.Collections.Generic;


namespace Challenge2.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        public Entry getEntry()
        {
            Entry entry1 = new Entry("test", 1, 1);
          //  entry1.username = "test";
          //  entry1.score = 1;
           // entry1.index = 1;

            return entry1; 
        }

        public List<Entry> getLeaderboard()
        {
            List<Entry> leaderboard = new List<Entry>();
            leaderboard.Add(new Entry("Allan", 0, 1));
            leaderboard.Add(new Entry("Joshua", 1, 2));
            leaderboard.Add(new Entry("Nick", 2, 3));
            
            return leaderboard;
        }

        public LeaderboardModel getLeaderboardModel()
        {
            LeaderboardModel model = new LeaderboardModel();
            model.LeaderboardEntries.Add(new Entry("Allan", 0, 1));
            model.LeaderboardEntries.Add(new Entry("Joshua", 1, 2));
            model.LeaderboardEntries.Add(new Entry("Nick", 2, 3));
            model.page = 1;
            model.count = model.LeaderboardEntries.Count;

            return model; 
        }
    }
}
