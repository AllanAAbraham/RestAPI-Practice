﻿namespace Challenge2.Models
{
    //Entry Object, A Leaderboard will contain a list of entries
    public class Entry
    {
        public string? username { get; set; }
        public int index { get; set; }
        public int score { get; set; }

        public Entry(string un, int ind, int sre)
        {
            username = un;
            index = ind;
            score = sre;
        }

    }
}