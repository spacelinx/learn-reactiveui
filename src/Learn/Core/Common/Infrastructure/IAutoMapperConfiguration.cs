using AutoMapper;

namespace Learn.Core.Common.Infrastructure
{
    public interface IAutoMapperConfiguration
    {
        void ConfigureAutomapper(IMapperConfigurationExpression cfg);
    }
}