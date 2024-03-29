﻿using Challenge2.Interfaces;
using Challenge2.Models;
using Newtonsoft.Json;

namespace Challenge2.Services
{
    
    public class LeaderboardService : ILeaderboardService
    {
        public static LeaderboardModel model = new LeaderboardModel();
        private readonly IConfiguration _config;        //Used for accessing config file for datafile path
        private readonly IWebHostEnvironment _hostingEnvironment; //Used for building API file path
        // var redis = RedisStore.RedisCache {setting up redis cache}
        // RedisKey RedisLeaderboard = "LeaderboardKey" {setting up leaderboard key}
        // If actually implementing redis, would remove global model. Data entries would be added straight into entries and sorted within AddEntries.
        // Subset would be taken out of redis and put into LeaderboardModel page in getLeaderboardModel and returned to controller

        public LeaderboardService(IConfiguration config, IWebHostEnvironment hostingEnvironment)
        {
            _config = config;
            _hostingEnvironment = hostingEnvironment;
        }

        public void addEntries(List<Entry> e) //from GET, user can input entries into LeaderboardEntries
        {
            //Validating that e inpput is valid. e has to contain data
            if((e != null) && (e.Count > 0 ))
            {
                for (int i = 0; i < e.Count; i++)
                {
                    model.leaderboardEntries.Add(e[i]);
                    //redis.SortedSetAdd(RedisLeaderboard, e[i], e[i].score); Adding entries into the cache of redis
                }
                
            }
            else
            {
                //throw bad request if nothing is sent
                throw new InvalidOperationException("Entry is invalid");
            }
            
        }

        public LeaderboardModel getLeaderboardModel(int pageNum, int n)  //Takes in two optional querystring parameters
        {
            if (model.leaderboardEntries.Count == 0) // Validates that current dataset of entries has entries
            {   // if there are no entries, api will add data from a json file that is configurable in appsettings.json
                string contentRootPath = _hostingEnvironment.ContentRootPath + _config["Datapath"];
                List<Entry> ent = JsonConvert.DeserializeObject<List<Entry>>(File.ReadAllText(contentRootPath)); //converting data file into a readable list of entries
               
                //Validates that data file added above contains valid entries
                try
                {
                    addEntries(ent);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Data File could not be read");
                }
                
            }
            // Checks if current number of entries is compared to n displayed number of entries
            if(model.leaderboardEntries.Count < n)
            {
                n = model.leaderboardEntries.Count; //this makes sure that the api only current displays entries that are available 
            }

            //var EntriesByScore = redis.SortedSetRangeByScore(LeaderboardKey, 1, model.LeaderboardEntries.Count, Exclude.None, Order.Descending); // This should return a list of all entries that is ordered from highest to lowest score
            
            LeaderboardModel page = new LeaderboardModel(); //creating a subset of model to be returned to controller

            //page.LeaderboardEntries = EntriesByScore.GetRange((pageNum - 1) * n, Math.Min(n, model.LeaderboardEntries.Count - ((pageNum - 1) * n)));
            //This should add the subset (determined by pageNum and n) of the the List of sorted entries 

            //Adds a subset of entries based on optional querystring parameters. 
            //The first value (pageNum - 1) * n) calculates the offset of the model file (how many entries are skipped first)
            //The second value [Math.Min(n, model.LeaderboardEntries.Count - ((pageNum - 1) * n))] calculates number of entries to add to page. 
            //Math.Min is used in case if the user is querying for the last page of entries and the remaining total of entries is less than the n query. Page will contain the remaing number of entries.
            
            //validating that minimum is not a negative value and throw error message back to controller
            if(Math.Min(n, model.leaderboardEntries.Count - ((pageNum - 1) * n)) <= 0)
            {
                throw new InvalidOperationException("No more entries to display");
            }
            
            page.leaderboardEntries = model.leaderboardEntries.GetRange((pageNum - 1) * n, Math.Min(n, model.leaderboardEntries.Count - ((pageNum - 1) * n)));
            // subset will display total entries in model
            page.count = model.leaderboardEntries.Count;
            // page number is dispalyed in post output
            page.page = pageNum;
                
            return page; 
        }
    }
}