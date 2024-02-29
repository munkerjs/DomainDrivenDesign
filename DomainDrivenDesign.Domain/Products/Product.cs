using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product : BaseEntity
    {
        private Product(Guid id) : base(id) { }  // add-migration yaparken hata atmaması için
        public Product(Guid id, Name name, int stockQuantity, Money price, Guid categoryId) : base(id)
        {
            Name = name;
            StockQuantity = stockQuantity;
            Price = price;
            CategoryId = categoryId;
        }

        public Name Name { get; private set; }    
        // public string Description { get; private set; }
        public int StockQuantity { get; private set; }
        public Money Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public void ChangeName(string name) => Name = new(name);
        public void Update(string name,int stockQuantity, decimal amount, string currency, Guid categoryId)
        {
            Name = new(name);
            StockQuantity = stockQuantity;
            Price = new(amount, Currency.FromCode(currency));
            CategoryId = categoryId;
        }
    }
}
