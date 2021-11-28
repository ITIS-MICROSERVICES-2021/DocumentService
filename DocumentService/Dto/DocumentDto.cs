using System;

namespace DocumentService.Dto
{
    public class DocumentDto
    {
        /// <summary>
        /// Who writes the application
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// When the application is created
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// First day of vacation date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Last day of vacation date
        /// </summary>
        public DateTimeOffset EndDate { get; set; }
    }
}
