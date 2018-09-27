using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClientAPI.Models
{
    public class Goals : BaseEntity
    {
        public int GoalsId { get; set; }
        public string Goal { get; set; }
        public int TargetYear { get; set; }
        public string TargetMonth { get; set; }
        public DateTime AccomplishedDate { get; set; }
        public bool IsAccomplished { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<GoalRemarks> GoalRemarks { get; set; }

    }
}