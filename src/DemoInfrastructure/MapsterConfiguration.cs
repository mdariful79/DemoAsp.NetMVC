using DemoApplication.Features.Products.Command;
using DemoDomain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInfrastructure
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductAddCommand, Product>();
        }
    }
}
