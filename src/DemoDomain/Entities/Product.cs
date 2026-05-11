using DemoDomain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Entities
{
    public class Product : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
