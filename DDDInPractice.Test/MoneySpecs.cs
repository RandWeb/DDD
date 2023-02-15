using DDDInPractice.Logic.ValueObjects;

namespace DDDInPractice.Test;
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

    [DataTestMethod]
    [DataRow(0, 0, 0, 0, 0, 0, 0)]
    [DataRow(1, 0, 0, 0, 0, 0, 0.01)]
    [DataRow(1, 2, 0, 0, 0, 0, 0.21)]
    [DataRow(1, 2, 0, 1, 0, 0, 1.21)]
    [DataRow(1, 2, 3, 4, 5, 6, 149.96)]
    [DataRow(110, 0, 0, 0, 100, 0, 501.1)]
    public void Amount_is_calculated_correctly(
                                                int oneCentCount,
                                                int tenCentCount,
                                                int quarterCount,
                                                int oneDollarCount,
                                                int fiveDollarCount,
                                                int twentyDollarCount,
                                                double excpectedAmount)
    {
        var money = new Money(
                                        oneCentCount,
                                        tenCentCount,
                                        quarterCount,
                                        oneDollarCount,
                                        fiveDollarCount,
                                        twentyDollarCount);
        Assert.AreEqual(money.Amount, (decimal)excpectedAmount);
    }

    [TestMethod]
    public void Substraction_of_two_moneys_produces_correct_result()
    {
        // Arrange
        var money1 = new Money(1, 2, 3, 4, 5, 6);
        var money2 = new Money(1, 2, 3, 4, 5, 6);

        // Act
        var substraction = money1 - money2;

        // Assert
        Assert.AreEqual(0, substraction.OneCentCount);
        Assert.AreEqual(0, substraction.TenCentCount);
        Assert.AreEqual(0, substraction.QuarterCount);
        Assert.AreEqual(0, substraction.OneDollarCount);
        Assert.AreEqual(0, substraction.FiveDollarCount);
        Assert.AreEqual(0, substraction.TwentyDollarCount);
    }

    [TestMethod]
    public void Cannot_substract_more_than_exists()
    {
        // Arrange
        var tenCent = new Money(0, 1, 0, 0, 0, 0);
        var oneCent = new Money(1, 0, 0, 0, 0, 0);

        // Act
        Action action = () =>
        {
            var substract = tenCent - oneCent;
        };

        //Assert
        Assert.ThrowsException<InvalidOperationException>(action);
    }
}