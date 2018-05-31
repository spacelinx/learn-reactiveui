using System;
using AutoMapper;
using Learn.Core.Common.Interfaces;

namespace Learn.Core.Models
{
    public class CourseSummaryDto : IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string CourseQueryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public TimeSpan? Duration{ get; set; }
        public long? ViewCount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configurationProvider)
        {
            configurationProvider.CreateMap<Course, CourseSummaryDto>();
        }
    }
}
