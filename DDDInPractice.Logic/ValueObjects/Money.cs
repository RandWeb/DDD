using DDDInPractice.Logic.Shared;

namespace DDDInPractice.Logic.ValueObjects;
public class Money : ValueObject<Money>
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
        this.Validate();
    }

    public static Money Empty() => new Money(0, 0, 0, 0, 0, 0);

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

    public static Money operator -(Money moneyOne, Money moneyTwo)
    {
        return new Money(
                        moneyOne.OneCentCount - moneyTwo.OneCentCount,
                        moneyOne.TenCentCount - moneyTwo.TenCentCount,
                        moneyOne.QuarterCount - moneyTwo.QuarterCount,
                        moneyOne.OneDollarCount - moneyTwo.OneDollarCount,
                        moneyOne.FiveDollarCount - moneyTwo.FiveDollarCount,
                        moneyOne.TwentyDollarCount - moneyTwo.TwentyDollarCount);
    }



    public decimal Amount => OneCentCount * 0.01m
                            + TenCentCount * 0.10m
                            + QuarterCount * 0.25m
                            + OneDollarCount
                            + FiveDollarCount * 5
                            + TwentyDollarCount * 20;

    protected override bool EqualsCore(Money other)
    {
        return OneCentCount == other.OneCentCount
            && TenCentCount == other.TenCentCount
            && QuarterCount == other.QuarterCount
            && OneDollarCount == other.OneDollarCount
            && FiveDollarCount == other.FiveDollarCount
            && TwentyDollarCount == other.TwentyDollarCount;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            int hashCode = OneCentCount;
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;
            return hashCode;
        }
    }

    protected override void Validate()
    {
        if (OneCentCount < 0) throw new InvalidOperationException();

        if (TenCentCount < 0) throw new InvalidOperationException();

        if (QuarterCount < 0) throw new InvalidOperationException();

        if (OneDollarCount < 0) throw new InvalidOperationException();

        if (FiveDollarCount < 0) throw new InvalidOperationException();

        if (TwentyDollarCount < 0) throw new InvalidOperationException();
    }
}