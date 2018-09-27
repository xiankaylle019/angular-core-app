using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;

namespace ClientAPI.Shared.DTOs
{
    public class GoalRemarksDTO : BaseEntityDTO, IMapSource<GoalRemarks>
    {
        public int GoalRemarksId { get; set; }        
        public string Remarks { get; set; }

    }
}