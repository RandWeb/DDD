using DDDInPractice.Logic.Shared;
using DDDInPractice.Logic.ValueObjects;
using static DDDInPractice.Logic.ValueObjects.Money;
namespace DDDInPractice.Logic;
public class SnackMachine : Entity
{
    public SnackMachine()
    {
        MoneyInside = Empty;
        MoneyInTransction = Empty;

        Slots = new List<Slot> {
        new Slot(this,null,1,0m,0),
        new Slot(this,null,2,0m,0),
        new Slot(this,null,3,0m,0),
        };
    }

    public Money MoneyInside { get; private set; } = Empty;

    public Money MoneyInTransction { get; private set; } = Empty;

    public int OneCentCountInTransaction { get; private set; }

    public int TenCentCountInTransaction { get; private set; }

    public int QuarterCountInTransaction { get; private set; }

    public int OneDollarCountInTransaction { get; private set; }

    public int FiveDollarCountInTransaction { get; private set; }

    public int TwentyDollarCountInTransaction { get; private set; }

    public IList<Slot> Slots { get; protected set; } = new List<Slot>();

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

    public void BuySnack(int position)
    {
        Slot slot = Slots.Single(x => x.Position == position);
        slot.Quantity--;

        MoneyInside += MoneyInTransction;

        MoneyInTransction = Empty;
    }

    public void LoadSnacks(int position, Snack snack, int quantity, decimal price)
    {
        Slot slot = Slots.Single(x => x.Position == position);

        slot.Snack = snack;
        slot.Quantity = quantity;
        slot.Price = price;
    }
}
