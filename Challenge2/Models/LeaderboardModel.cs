

namespace Challenge2.Models
{
    public class LeaderboardModel
    {
        //Wrapper data object that will contain list of Entries, current page number, and total number of entries
        public List<Entry>? LeaderboardEntries { get; set; }
        public int page { get; set; }
        public int count { get; set; }

        public LeaderboardModel()
        {
            LeaderboardEntries = new List<Entry>();
        }
    }
}
