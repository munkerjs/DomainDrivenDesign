
Guid id = Guid.NewGuid();
A a1 = new A(id);
A a2 = new A(id);

Console.WriteLine(a1.Equals(a2));
Console.ReadLine();


public abstract class BaseEntity
{
    public Guid Id { get; init; }
    public BaseEntity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is not BaseEntity entity)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }
}

public class A : BaseEntity
{
    public A(Guid id) : base(id) { }

}