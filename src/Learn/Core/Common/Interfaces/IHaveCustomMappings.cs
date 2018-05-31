using AutoMapper;

namespace Learn.Core.Common.Interfaces
{
	public interface IHaveCustomMappings
	{
        void CreateMappings(IMapperConfigurationExpression configurationProvider);
	}
}
