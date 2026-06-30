using DemoApplication.Features.Products.Command;
using DemoDomain.Entities;
using DemoWeb.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWeb
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductAddCommand, Product>();
            config.NewConfig<CreateProductModel, ProductAddCommand>();
        }
    }
}
