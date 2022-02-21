﻿using Challenge2.Models;
using System.Collections.Generic;

namespace Challenge2.Interfaces
{
    public interface ILeaderboardService
    {
        public Entry getEntry();
        public string addEntry(Entry e);
        public List<Entry> getLeaderboard();
        public LeaderboardModel getLeaderboardModel();
    }
}
