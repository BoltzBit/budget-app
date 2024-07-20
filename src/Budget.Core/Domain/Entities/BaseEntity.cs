namespace Budget.Core.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected BaseEntity(){
        Id = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        var compareTo = obj as BaseEntity;

        if(ReferenceEquals(this, obj)){
            return true;
        }

        if(ReferenceEquals(null, obj)){
            return false;
        }

        return Id.Equals(compareTo!.Id);
    }

    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        if(ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }

        if(ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode()*907 + Id.GetHashCode();
    }
}
