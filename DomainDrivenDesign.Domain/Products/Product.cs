using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product : BaseEntity
    {
        public Product(Guid id) : base(id)
        {
        }

        public string Name { get; set; }    
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
