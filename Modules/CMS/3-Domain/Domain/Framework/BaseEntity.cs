namespace Domain.Framework;

public abstract class BaseEntity
{
    public virtual long Id { get; protected set; }

    public virtual DateTime SubmitDate { get; protected set; }

    private List<Event> _domainEvents;
    public IReadOnlyCollection<Event> DomainEvents
    {
        get
        {
            List<Event> domainEvents = this._domainEvents;
            return domainEvents == null ?
                (IReadOnlyCollection<Event>)null :
                (IReadOnlyCollection<Event>)domainEvents.AsReadOnly();
        }
    }

    public void AddDomainEvent(Event domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<Event>();
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public override bool Equals(object obj)
    {
        BaseEntity entity = obj as BaseEntity;
        if ((object)this == entity)
        {
            return true;
        }

        if ((object)entity == null)
        {
            return false;
        }

        return Id.Equals(entity.Id);
    }

    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        if ((object)a == null && (object)b == null)
        {
            return true;
        }

        if ((object)a == null || (object)b == null)
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
        return (GetType().GetHashCode() ^ 0x5D) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}