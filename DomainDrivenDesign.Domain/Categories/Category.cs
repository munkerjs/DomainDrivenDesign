using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Categories
{
    public sealed class Category : BaseEntity
    {
        private Category(Guid id) : base(id) { } // add-migration yaparken hata atmaması için
        public Category(Guid Id, Name name) : base(Id)
        {
            Name = name;
        }

        public Name Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public void ChangeName(string name) => Name = new(name);
    }
}
