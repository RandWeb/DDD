namespace DDDInPractice.Logic.ValueObjects;

public class Money
{
    public Money(
                int oneCentCount,
                int tenCentCount,
                int quarterCount,
                int oneDollarCount,
                int fiveDollarCount,
                int twentyDollarCount)
    {
        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        QuarterCount = quarterCount;
        OneDollarCount = oneDollarCount;
        FiveDollarCount = fiveDollarCount;
        TwentyDollarCount = twentyDollarCount;
    }

    public int OneCentCount { get; private set; }
    public int TenCentCount { get; private set; }
    public int QuarterCount { get; private set; }
    public int OneDollarCount { get; private set; }
    public int FiveDollarCount { get; private set; }
    public int TwentyDollarCount { get; private set; }

    public static Money operator +(Money moneyOne, Money moneyTwo)
    {
        return new Money(
                        moneyOne.OneCentCount + moneyTwo.OneCentCount,
                        moneyOne.TenCentCount + moneyTwo.TenCentCount,
                        moneyOne.QuarterCount + moneyTwo.QuarterCount,
                        moneyOne.OneDollarCount + moneyTwo.OneDollarCount,
                        moneyOne.FiveDollarCount + moneyTwo.FiveDollarCount,
                        moneyOne.TwentyDollarCount + moneyTwo.TwentyDollarCount);
    }
}