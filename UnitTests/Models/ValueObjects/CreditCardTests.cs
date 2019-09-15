using DomainLogic.ValueObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Models.ValueObjects
{
    public class CreditCardTests
    {
        [Test]
        public void Equals()
        {
            var cardA = CreditCard.BarclayCard();
            var cardB = CreditCard.BarclayCard();
            var cardC = CreditCard.Vanquish();
            Assert.IsTrue(cardA == cardB);
            Assert.IsFalse(cardB == cardC);
        }

        [Test]
        public void Distinct()
        {
            List<CreditCard> list = new List<CreditCard>
            {
                CreditCard.BarclayCard(),
                CreditCard.BarclayCard(),
                CreditCard.Vanquish()
            };

            Assert.AreEqual(2, list.Distinct().Count());
        }
    }
}