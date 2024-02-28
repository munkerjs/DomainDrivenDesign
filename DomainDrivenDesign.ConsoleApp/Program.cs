﻿
using BenchmarkDotNet.Running;
using DomainDrivenDesign.ConsoleApp;

BenchmarkRunner.Run<BenchmarkService>();
Console.ReadLine();


public abstract class BaseEntity : IEquatable<BaseEntity>
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

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(BaseEntity? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other is not BaseEntity entity)
        {
            return false;
        }

        if (other.GetType() != GetType())
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