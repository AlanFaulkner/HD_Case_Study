using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.ViewModels.ResultDTOs
{
    /// <summary>
    /// Data binding object used to display applicants data in database view table
    /// </summary>
    public class ApplicantResultsDTO
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
        [Column(TypeName = "decimal(8,2)")]
        public double AnnualIncome { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string CreditCardName { get; set; }
    }
}