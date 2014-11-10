using System;
using System.Data.Entity;

namespace MultiPolls.Models
{
    public class Poll
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public string CreatorID { get; set; }
        public string PollQuestion { get; set; }
        public int OptionA { get; set; }
        public int OptionB { get; set; }
        public int OptionC { get; set; }
        public int OptionD { get; set; }
        public int OptionE { get; set; }
        public int OptionF { get; set; }
        public int OptionG { get; set; }
        public int OptionH { get; set; }
        public int OptionI { get; set; }
        public int OptionJ { get; set; }
    }

    public class PollDBContext : ApplicationDbContext
    {
        public DbSet<Poll> Polls { get; set; }
    }
}