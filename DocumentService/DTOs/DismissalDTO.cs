namespace DocumentService.DTOs
{
    /// <summary>
    /// Base DTO for template fields
    /// </summary>
    
    public class TemplateDTO
    {
        /// <summary>
        /// To whom the application is written
        /// </summary>
        public string ToWhom { get; set; }

        /// <summary>
        /// Who writes the application
        /// </summary>
        public string FromWhom { get; set; }

        /// <summary>
        /// Start date day
        /// </summary>
        public string StartDateDay { get; set; }

        /// <summary>
        /// Start date month
        /// </summary>
        public string StartDateMonth { get; set; }

        /// <summary>
        /// Start date year
        /// </summary>
        public string StartDateYear { get; set; }

        /// <summary>
        /// Applicant's full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Date day
        /// </summary>
        public string DateDay { get; set; }

        /// <summary>
        /// Date month
        /// </summary>
        public string DateMonth { get; set; }

        /// <summary>
        /// Date year
        /// </summary>
        public string DateYear { get; set; }

    }

}