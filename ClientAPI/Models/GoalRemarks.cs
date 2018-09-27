namespace ClientAPI.Models
{
    public class GoalRemarks : BaseEntity
    {
        public int GoalRemarksId { get; set; }        
        public string Remarks { get; set; }
        public int GoalId { get; set; }
        public virtual Goals Goals { get; set; }
        

    }
}