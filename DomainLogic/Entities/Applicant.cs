using DomainLogic.ValueObjects;
using System;

namespace DomainLogic.Entities
{
    public sealed class Applicant
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public double AnnualIncome { get; }
        public int Age => (DateTime.Today - DateOfBirth.Date).Days / 365;

        public CreditCard ApplicableCreditCard { get; private set; } = CreditCard.NotApproved();

        /// <summary>
        /// Public constructor - creates a valid applicant
        /// </summary>
        /// <param name="firstName"> Applicants first name </param>
        /// <param name="lastName"> Applicants last name </param>
        /// <param name="dateOfBirth"> Applicants Date of Birth </param>
        /// <param name="annualIncome"> Applicants annual income </param>
        public Applicant(string firstName, string lastName, DateTime dateOfBirth, double annualIncome)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            AnnualIncome = annualIncome;
            IsValid();
        }

        /// <summary>
        /// Used for when updating properties on applicants
        /// </summary>
        /// <param name="id"> Database Id </param>
        /// <param name="firstName"> Applicants first name </param>
        /// <param name="lastName"> Applicants last name </param>
        /// <param name="dateOfBirth"> Applicants Date of Birth </param>
        /// <param name="annualIncome"> Applicants annual income </param>
        /// <param name="card"> Applicants credit product </param>
        private Applicant(Guid id, string firstName, string lastName, DateTime dateOfBirth, double annualIncome,
            CreditCard card)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            AnnualIncome = annualIncome;
            ApplicableCreditCard = card;
        }

        /// <summary>
        /// Determines what credit product is suitable for the applicant.
        /// </summary>
        /// <returns> new instance of applicant with their assigned credit product. </returns>
        public Applicant ApproveApplication()
        {
            if (Age > 18 && AnnualIncome > 30000)
                return new Applicant(this.Id, this.FirstName, this.LastName, this.DateOfBirth, this.AnnualIncome,
                    CreditCard.BarclayCard());
            if (Age > 18)
                return new Applicant(this.Id, this.FirstName, this.LastName, this.DateOfBirth, this.AnnualIncome,
                CreditCard.Vanquis());

            return this;
        }

        /// <summary>
        /// Validates properties on public construction of entity
        /// </summary>
        private void IsValid()
        {
            if (string.IsNullOrEmpty(FirstName)) throw new ArgumentException("First name can not be null or empty.");
            if (string.IsNullOrEmpty(LastName)) throw new ArgumentException("Last name can not be null or empty.");
            if (AnnualIncome < 0) throw new ArgumentException("Annual Income must be a positive value");
            if (DateOfBirth >= DateTime.Now) throw new ArgumentException("Please enter a valid date of birth.");
            if (Age > 100) throw new ArgumentException("Date ofg birth should be within the last 100 years.");
        }
    }
}