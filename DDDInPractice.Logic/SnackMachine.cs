using DDDInPractice.Logic.ValueObjects;

namespace DDDInPractice.Logic;
public sealed class SnackMachine
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransction { get; private set; }
    public int OneCentCountInTransaction { get; private set; }
    public int TenCentCountInTransaction { get; private set; }
    public int QuarterCountInTransaction { get; private set; }
    public int OneDollarCountInTransaction { get; private set; }
    public int FiveDollarCountInTransaction { get; private set; }
    public int TwentyDollarCountInTransaction { get; private set; }

    public void AddMoeny(Money money)
    {
        MoneyInTransction += money;
    }

    public void ReturnMony()
    {
        // MoneyInTransction = 0;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransction;
        // MoneyInTransction = 0;
    }
}
