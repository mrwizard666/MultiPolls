using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MultiPolls.Models
{
    public class Poll
    {
        public int ID { get; set; }
        [Display(Name = "Date Created")]
        [Column(TypeName="datetime2")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName="datetime2")]
        public DateTime EditDate { get; set; }
        [Display(Name = "Author")]
        public string CreatorID { get; set; }
        [Display(Name = "Poll Question")]
        public string PollQuestion { get; set; }
        [Display(Name = "Option A")]
        public string OptionA { get; set; }
        [Display(Name = "Option B")]
        public string OptionB { get; set; }
        [Display(Name = "Option C")]
        public string OptionC { get; set; }
        [Display(Name = "Option D")]
        public string OptionD { get; set; }
        [Display(Name = "Option E")]
        public string OptionE { get; set; }
        [Display(Name = "Option F")]
        public string OptionF { get; set; }
        [Display(Name = "Option G")]
        public string OptionG { get; set; }
        [Display(Name = "Option H")]
        public string OptionH { get; set; }
        [Display(Name = "Option I")]
        public string OptionI { get; set; }
        [Display(Name = "Option J")]
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
        public bool IsPublished { get; set; }
        public bool IsPublic { get; set; }
        public bool HasVoted { get; set; }
        public bool UsernameVisible { get; set; }    
    }

    public class PollDBContext : MainDbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<VoteLog> VoteLogs { get; set; }
    }
}