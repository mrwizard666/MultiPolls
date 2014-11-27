using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultiPolls.Models
{
    public class VoteLog
    {
        [Key]
        public int VoteID { get; set; }
        public int QuestionID { get; set; }
        public string User { get; set; }
    }
}