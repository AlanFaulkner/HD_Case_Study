using DomainLogic.Entities;
using NUnit.Framework;
using System;

namespace UnitTests.Models.Entities
{
    public class ApplicantTests
    {
        [Test]
        public void Creation()
        {
            Assert.DoesNotThrow(() => new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/1986"), 34000));
            Assert.Throws<ArgumentException>(
                () => new Applicant("", "Faulkner", DateTime.Parse("25/10/1986"), 34000));
            Assert.Throws<ArgumentException>(
                () => new Applicant("Alan", null, DateTime.Parse("25/10/1986"), 34000));
            Assert.Throws<ArgumentException>(() => new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/1986"), -3));
            Assert.Throws<ArgumentException>(() =>
                new Applicant("Alan", "Faulkner", DateTime.Today.AddDays(1), 36000));
            Assert.Throws<ArgumentException>(() =>
                new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/1886"), 36000));
        }

        [Test]
        public void Approval()

        {
            var barclayCard = new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/1986"), 34000);
            Assert.AreEqual("BarclayCard", barclayCard.ApproveApplication().ApplicableCreditCard.CreditCardName);

            var vanquishCard = new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/1986"), 18000);
            Assert.AreEqual("Vanquish", vanquishCard.ApproveApplication().ApplicableCreditCard.CreditCardName);

            var none = new Applicant("Alan", "Faulkner", DateTime.Parse("25/10/2012"), 34000);
            Assert.AreEqual("None", none.ApproveApplication().ApplicableCreditCard.CreditCardName);
        }
    }
}