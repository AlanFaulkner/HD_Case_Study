using System;
using System.Linq;

namespace DomainLogic.ValueObjects
{
    public class CreditCard : ValueObject<CreditCard>
    {
        public string CreditCardName { get; }
        public double APR { get; }
        public string Image { get; }
        public string WelcomeMessage { get; }

        private CreditCard(string name, double apr, string image, string message)
        {
            CreditCardName = name;
            APR = apr;
            WelcomeMessage = message;
            Image = image;
        }

        /// <summary>
        /// Static generation functions for known credit cards
        /// </summary>
        /// <returns></returns>
        public static CreditCard BarclayCard()
        {
            return new CreditCard("BarclayCard", 18.6, "images/BarclayCard.jpg", $"You have been approved for a Barclay's Credit Card at 12.2% APR");
        }

        public static CreditCard Vanquis()
        {
            return new CreditCard("Vanquis", 12.2, "images/Vanquis.jpg", "You have been approved for a Vanquis Credit Card at 18.6% APR");
        }

        public static CreditCard NotApproved()
        {
            return new CreditCard("None", 0, "images/Declined.png", "You have not been approved for any credit products at this time");
        }

        protected override bool EqualsCore(CreditCard other)
        {
            return CreditCardName == other.CreditCardName
                   && Math.Abs(APR - other.APR) < Tolerance
                   && WelcomeMessage == other.WelcomeMessage
                   && Image == other.Image;
        }

        protected override int GetHashCodeCore()
        {
            return this.GetType().GetProperties().Aggregate(0,
                (current, property) => (current * 397) ^ property.GetValue(this).GetHashCode());
        }
    }
}