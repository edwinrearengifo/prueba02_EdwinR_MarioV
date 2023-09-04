using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPracticaVersion2.Models.Teams
{
    
    /*public class Fixtures
    {
        public Team team { get; set; }
        //public Fixtures Fixtures { get; set; }
        //public Goals Goals { get; set; }
        //public Biggest Biggest { get; set; }
        //public int CleanSheet { get; set; }
        //public int FailedToScore { get; set; }
        //public Penalty Penalty { get; set; }
        //public List<object> Lineups { get; set; }
        //public Cards Cards { get; set; }
    }*/

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class Fixtures
    {
        public Played Played { get; set; }
        public Wins Wins { get; set; }
        public Draws Draws { get; set; }
        public Loses Loses { get; set; }
    }

    public class Played
    {
        public int Home { get; set; }
        public int Away { get; set; }
        public int Total { get; set; }
    }

    public class Wins
    {
        public int Home { get; set; }
        public int Away { get; set; }
        public int Total { get; set; }
    }

    public class Draws
    {
        public int Home { get; set; }
        public int Away { get; set; }
        public int Total { get; set; }
    }

    public class Loses
    {
        public int Home { get; set; }
        public int Away { get; set; }
        public int Total { get; set; }
    }

    public class Goals
    {
        public For For { get; set; }
        public Against Against { get; set; }
    }

    public class For
    {
        public Total Total { get; set; }
    }

    public class Total
    {
        public int Home { get; set; }
        public int Away { get; set; }
        public int total { get; set; }
    }

    public class Against
    {
        public Total Total { get; set; }
    }

    public class Biggest
    {
        public Streak Streak { get; set; }
        public Wins Wins { get; set; }
        public Loses Loses { get; set; }
        public Goals Goals { get; set; }
    }

    public class Streak
    {
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
    }

    public class Penalty
    {
        public Scored Scored { get; set; }
        public Missed Missed { get; set; }
        public int Total { get; set; }
    }

    public class Scored
    {
        public int Total { get; set; }
        public string Percentage { get; set; }
    }

    public class Missed
    {
        public int Total { get; set; }
        public string Percentage { get; set; }
    }

    public class Cards
    {
        public Yellow Yellow { get; set; }
        public Red Red { get; set; }
    }

    public class Yellow
    {
        public Dictionary<string, object> Total { get; set; }
    }

    public class Red
    {
        public Dictionary<string, object> Total { get; set; }
    }

}