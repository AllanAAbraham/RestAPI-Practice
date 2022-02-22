using Challenge2.Interfaces;
using Challenge2.Models;
using Newtonsoft.Json;

namespace Challenge2.Services
{
    
    public class LeaderboardService : ILeaderboardService
    {
        public static LeaderboardModel model = new LeaderboardModel();
        
        public Boolean addEntries(List<Entry> e)
        {
            for(int i = 0; i < e.Count; i++)
            {
                model.LeaderboardEntries.Add(e[i]); 
            }
            return true;
        }

        public LeaderboardModel getLeaderboardModel(int pageNum, int n, string data, int ydata)
        {
            if (ydata == 1 || model == null)
            {
                List<Entry> ent = JsonConvert.DeserializeObject<List<Entry>>(File.ReadAllText(data));
                if (!addEntries(ent))
                {
                    throw new InvalidOperationException("Data File could not be read");
                }
            }
            LeaderboardModel page = new LeaderboardModel();
            page.LeaderboardEntries = model.LeaderboardEntries.GetRange((pageNum - 1) * n, n);
            page.count = model.LeaderboardEntries.Count;
            page.page = pageNum;
            
            return page; 
        }
    }
}

//model.LeaderboardEntries.Add(new Entry("Allan", 0, 1));
// model.LeaderboardEntries.Add(new Entry("Joshua", 1, 2));
// model.LeaderboardEntries.Add(new Entry("Nick", 2, 3));
//model.page = 1;
// model.count = model.LeaderboardEntries.Count;
