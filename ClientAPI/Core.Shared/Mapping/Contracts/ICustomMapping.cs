using AutoMapper;

namespace ClientAPI.Core.Shared.Mapping.Contracts
{
    public interface ICustomMapping
    {
         void CreateMapping(IMapperConfigurationExpression cfg);
    }
}