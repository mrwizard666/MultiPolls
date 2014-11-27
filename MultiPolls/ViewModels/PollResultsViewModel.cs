using MultiPolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiPolls.ViewModels
{
    public class PollResultsViewModel
    {
        //public Poll Poll { get; set; }
        //public VoteLog Votelog { get; set; }

        //public PollResultsViewModel(Poll poll)
        //{
        //    Poll = new Poll;
        //    Votelog = 
        //}
        public Poll ID { get; set; }
        public Poll CreationDate { get; set; }
        public Poll PollQuestion { get; set; }
        public Poll CreatorID { get; set; }
        public Poll EditDate { get; set; }
        public Poll IsPublished { get; set; }
        public VoteLog QuestionID { get; set; }
        public VoteLog User { get; set; }
        
    }
}