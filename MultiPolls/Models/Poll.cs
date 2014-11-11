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
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string OptionF { get; set; }
        public string OptionG { get; set; }
        public string OptionH { get; set; }
        public string OptionI { get; set; }
        public string OptionJ { get; set; }
        public int AnswerA { get; set; }
        public int AnswerB { get; set; }
        public int AnswerC { get; set; }
        public int AnswerD { get; set; }
        public int AnswerE { get; set; }
        public int AnswerF { get; set; }
        public int AnswerG { get; set; }
        public int AnswerH { get; set; }
        public int AnswerI { get; set; }
        public int AnswerJ { get; set; }
    }

    public class PollDBContext : ApplicationDbContext
    {
        public DbSet<Poll> Polls { get; set; }
    }
}