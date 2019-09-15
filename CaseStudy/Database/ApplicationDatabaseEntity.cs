using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.DataTransferObjects.DatabaseDTOs
{
    /// <summary>
    /// Data structure stored in database
    /// </summary>
    public class ApplicationDatabaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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

        [Required]
        public string Image { get; set; }

        [Required]
        public double APR { get; set; }

        [Required]
        public string WelcomeMessage { get; set; }
    }
}