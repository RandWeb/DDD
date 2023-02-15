using DDDInPractice.Logic.ValueObjects;

namespace DDDInPractice.Test
{
    [TestClass]
    public class MoneySpecs
    {
        [TestMethod]
        public void Sum_of_to_two_moneys_produces_correct_result()
        {
            // Arrange
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            // Act
            var sum = money1 + money2;

            // Assert
            Assert.AreEqual(2, sum.OneCentCount);
            Assert.AreEqual(4, sum.TenCentCount);
            Assert.AreEqual(6, sum.QuarterCount);
            Assert.AreEqual(8, sum.OneDollarCount);
            Assert.AreEqual(10, sum.FiveDollarCount);
            Assert.AreEqual(12, sum.TwentyDollarCount);
        }

        [TestMethod]
        public void Two_money_instaces_equal_if_contain_the_same_money_amount()
        {
            // Arrange
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            // Assert
            Assert.AreEqual(money1, money2);
            Assert.AreEqual(money2.GetHashCode(), money1.GetHashCode());
        }

        [TestMethod]
        public void Two_money_instaces_do_not_equal_if_contain_different_money_amount()
        {
            // Arrange
            var dollar = new Money(0, 0, 0, 4, 0, 0);
            var cent = new Money(100, 0, 0, 0, 0, 0);

            // Assert
            Assert.AreNotEqual(dollar, cent);
            Assert.AreNotEqual(cent.GetHashCode(), dollar.GetHashCode());
        }
        [DataTestMethod]
        [DataRow(-1, 0, 0, 0, 0, 0)]
        [DataRow(0, -2, 0, 0, 0, 0)]
        [DataRow(0, 0, -3, 0, 0, 0)]
        [DataRow(0, 0, 0, -4, 0, 0)]
        [DataRow(0, 0, 0, 0, -5, 0)]
        [DataRow(0, 0, 0, 0, 0, -6)]
        public void Cannot_create_money_with_negative_value(
                                                            int oneCentCount,
                                                            int tenCentCount,
                                                            int quarterCount,
                                                            int oneDollarCount,
                                                            int fiveDollarCount,
                                                            int twentyDollarCount)
        {
            Action action = () => new Money(
                                            oneCentCount,
                                            tenCentCount,
                                            quarterCount,
                                            oneDollarCount,
                                            fiveDollarCount,
                                            twentyDollarCount);
            Assert.ThrowsException<InvalidOperationException>(() => action());
        }
    }
}