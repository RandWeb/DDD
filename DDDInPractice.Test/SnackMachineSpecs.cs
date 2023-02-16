using DDDInPractice.Logic;
using static DDDInPractice.Logic.ValueObjects.Money;

namespace DDDInPractice.Test;
[TestClass]
public class SnackMachineSpecs
{
    [TestMethod]
    public void Return_money_empties_money_in_transaction()
    {
        var snackMachine = new SnackMachine();

        snackMachine.AddMoeny(OneDollar);

        snackMachine.ReturnMoney();

        Assert.AreEqual(snackMachine.MoneyInTransction.Amount, 0m);
    }

    [TestMethod]
    public void Inserted_money_goes_to_money_in_transaction()
    {
        var snackMachine = new SnackMachine();

        snackMachine.AddMoeny(OneDollar);

        snackMachine.AddMoeny(OneCent);

        Assert.AreEqual(snackMachine.MoneyInTransction.Amount, 1.01m);
    }
    [TestMethod]
    public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
    {
        var snackMachine = new SnackMachine();

        var twoCent = OneCent + OneCent;

        Action action = () => snackMachine.AddMoeny(twoCent);

        Assert.ThrowsException<InvalidOperationException>(action);
    }

    [TestMethod]
    public void Money_in_transaction_goes_to_money_inside_after_purchase()
    {
        var snackMachine = new SnackMachine();

        snackMachine.AddMoeny(OneDollar);

        snackMachine.AddMoeny(OneDollar);

        snackMachine.BuySnack(1);

        Assert.AreEqual(snackMachine.MoneyInTransction, Empty);

        Assert.AreEqual(snackMachine.MoneyInside.Amount, 2m);
    }

    [TestMethod]
    public void BuySnack_trades_inserted_money_for_a_snack()
    {
        var snackMachine = new SnackMachine();

        snackMachine.LoadSnacks(1, new Snack("Some snack"), 10, 1m);

        snackMachine.AddMoeny(OneDollar);

        snackMachine.BuySnack(1);

        Assert.AreEqual(snackMachine.MoneyInTransction, Empty);
        Assert.AreEqual(snackMachine.MoneyInside.Amount, 1m);

        Assert.AreEqual(snackMachine.Slots.Single(x => x.Position == 1).Quantity, 9);
    }
}

