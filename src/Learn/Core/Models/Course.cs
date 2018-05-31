using System;

namespace Learn.Core.Models
{
    public class Course 
    {
        private string _courseQueryId;
        private int _courseLongId;

        public Guid Id { get; set; }
        public string CourseQueryId => _courseQueryId;

        public int CourseLongId
        {
            get => _courseLongId;
            set
            {
                _courseLongId = value;
                _courseQueryId = CourseLongId.ToString();
            }
        }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

    }
}
