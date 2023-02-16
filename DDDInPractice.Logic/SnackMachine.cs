using DDDInPractice.Logic.Shared;
using DDDInPractice.Logic.ValueObjects;
using static DDDInPractice.Logic.ValueObjects.Money;
namespace DDDInPractice.Logic;
public class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; } = Empty;

    public Money MoneyInTransction { get; private set; } = Empty;

    public int OneCentCountInTransaction { get; private set; }

    public int TenCentCountInTransaction { get; private set; }

    public int QuarterCountInTransaction { get; private set; }

    public int OneDollarCountInTransaction { get; private set; }

    public int FiveDollarCountInTransaction { get; private set; }

    public int TwentyDollarCountInTransaction { get; private set; }

    public void AddMoeny(Money money)
    {
        var coins = new[] { OneCent, TenCent, Quarter, OneDollar, FiveDollar, TwentyDollar };

        if (!coins.Contains(money)) throw new InvalidOperationException();

        MoneyInTransction += money;
    }

    public void ReturnMoney()
    {
        MoneyInTransction = Empty;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransction;

        MoneyInTransction = Empty;
    }
}
