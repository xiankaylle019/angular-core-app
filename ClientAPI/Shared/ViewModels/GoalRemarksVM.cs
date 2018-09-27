using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;

namespace ClientAPI.Shared.ViewModels
{
    public class GoalRemarksVM  : BaseEntityVM, IMapDestination<GoalRemarks> 
    {
        public int GoalRemarksId { get; set; }        
        public string Remarks { get; set; }
    }
}