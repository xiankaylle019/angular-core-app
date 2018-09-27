using System;
using AutoMapper;
using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;
using Core.Shared.Mapping;

namespace ClientAPI.Shared.ViewModels
{
    public class GoalsVM : BaseEntityVM, ICustomMapping
    {
        public int GoalId { get; set; }
        public string Goal { get; set; }
        public int TargetYear { get; set; }
        public string TargetMonth { get; set; }
        public DateTime AccomplishedDate { get; set; }
        public bool IsAccomplished { get; set; }
        public GoalRemarksVM GoalRemarksVM { get; set; }
        public void CreateMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<GoalsVM, Goals>()
            .ForMember(d => d.GoalRemarks, opt => opt.MapFrom(s => s.GoalRemarksVM));

            cfg.IgnoreUnmapped();
        }
    }
}