using StackExchange.Redis.Extensions.MsgPack;

namespace DocumentService.DTOs
{
    /// <summary>
    /// DTO for vacation template fields
    /// </summary>
    
    
    public class VacationDTO : TemplateDTO
    {

        /// <summary>
        /// End date day
        /// </summary>
        public string EndDateDay { get; set; }

        /// <summary>
        /// End date month
        /// </summary>
        public string EndDateMonth { get; set; }

        /// <summary>
        /// End date year
        /// </summary>
        public string EndDateYear { get; set; }

        /// <summary>
        /// Vacation duration
        /// </summary>
        public string Duration { get; set; }

    }

}