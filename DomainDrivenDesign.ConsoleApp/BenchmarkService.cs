using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.ConsoleApp
{
    public class BenchmarkService
    {
        [Benchmark(Baseline = true)]
        public void Equals()
        {
            int Id = 1;
            Test1 test1 = new Test1();
            test1.Id = Id;

            Test1 test2 = new Test1();
            test2.Id = Id;

            Console.WriteLine(test1.Equals(test2));

        }

        [Benchmark]
        public void IEquatable()
        {
            int Id = 1;
            Test2 test1 = new Test2();
            test1.Id = Id;

            Test2 test2 = new Test2();
            test2.Id = Id;

            Console.WriteLine(test1.Equals(test2));
        }
    }

    public class Test1
    {
        public int Id { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not Test1 entity)
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

    public class Test2 : IEquatable<Test2>
    {
        public int Id { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not Test2 entity)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return entity.Id == Id;
        }

        public bool Equals(Test2? other)
        {
            if (other == null)
            {
                return false;
            }

            if (other is not Test2 entity)
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
}