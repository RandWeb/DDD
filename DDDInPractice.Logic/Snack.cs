using DDDInPractice.Logic.Shared;
using DDDInPractice.Logic.ValueObjects;

namespace DDDInPractice.Logic;
public class Snack : Entity
{
    public Snack(string name)
    {
        Name = name;
    }

    public virtual string Name { get; protected set; }
}

public class Slot : Entity
{
    public Slot(SnackMachine snackMachine, Snack snack, int position, decimal price, int quantity)
    {
        Snack = snack;
        SnackMachine = snackMachine;
        Position = position;
        Price = price;
        Quantity = quantity;
    }

    public Snack Snack { get; set; }

    public SnackMachine SnackMachine { get; set; }

    public int Position { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}


