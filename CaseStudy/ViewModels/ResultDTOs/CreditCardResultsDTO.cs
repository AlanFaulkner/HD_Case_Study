using System.ComponentModel.DataAnnotations;

namespace CaseStudy.DataTransferObjects.ResultsDTOs
{
    /// <summary>
    /// Data view used for data binding when applicant makes a successful application
    /// </summary>
    public class CreditCardResultsDTO
    {
        [Required]
        public string CreditCardName { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public double APR { get; set; }

        [Required]
        public string WelcomeMessage { get; set; }
    }
}