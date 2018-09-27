using System;
using AutoMapper;
using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;
using Core.Shared.Mapping;

namespace ClientAPI.Shared.DTOs
{
    public class GoalsDTO : BaseEntityDTO, ICustomMapping
    {
        public int GoalId { get; set; }
        public string Goal { get; set; }
        public int TargetYear { get; set; }
        public string TargetMonth { get; set; }
        public DateTime AccomplishedDate { get; set; }
        public bool IsAccomplished { get; set; }
        public GoalRemarksDTO GoalRemarksDTO { get; set; }
        public void CreateMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Goals, GoalsDTO>()
             .ForMember(d => d.GoalRemarksDTO, opt => opt.MapFrom(s => s.GoalRemarks));

            cfg.IgnoreUnmapped();
        }
    }
}