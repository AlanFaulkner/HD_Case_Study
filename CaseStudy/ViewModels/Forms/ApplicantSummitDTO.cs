using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.DataTransferObjects
{
    /// <summary>
    /// DTO used for data binding to application form
    /// </summary>
    public class ApplicantSummitDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double AnnualIncome { get; set; }
    }
}