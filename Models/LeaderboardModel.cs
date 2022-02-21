

namespace Challenge2.Models
{
    public class LeaderboardModel
    {
        
        public List<Entry>? LeaderboardEntries { get; set; }
        public int CurrentPageIndex { get; set; }
        public int page { get; set; }
        public int count { get; set; }

        public LeaderboardModel()
        {
            LeaderboardEntries = new List<Entry>();
        }
    }
}
