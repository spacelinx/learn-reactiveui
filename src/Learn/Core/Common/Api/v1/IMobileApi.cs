using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Learn.Core.Models;
using Refit;


namespace Learn.Core.Common.Api.v1
{
    public interface IMobileApi
    {
        [Get("/courses/forlogin?api-version=1.0")]
        Task<IEnumerable<CourseSummaryDto>> GetCoursesForLoginViewAsync();
        
        [Get("/courses/{courseId}")]
        Task<CourseSummaryDto> GetCourseAsync(Guid courseId);

        [Get("/courses/latest?api-version=1.0")]
        Task<IEnumerable<CourseSummaryDto>> GetCoursesLatestAsync();

        [Get("/courses/recommendedforuser/{userId}")]
        Task<IEnumerable<CourseSummaryDto>> GetCoursesRecommendedForUserAsync([Header("Authorization")]string token, Guid userId);
    }
}
