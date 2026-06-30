using Cortex.Mediator.Commands;
using DemoDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Features.Products.Command
{
    public class ProductAddCommand : ICommand<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
