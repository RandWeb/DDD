namespace DDDInPractice.Logic.Shared;
public abstract class Entity
{
    public long Id { get;private set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }


}

