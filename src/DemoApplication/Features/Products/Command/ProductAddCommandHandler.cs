using Cortex.Mediator.Commands;
using DemoApplication.Contracts;
using DemoDomain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Features.Products.Command
{
    public class ProductAddCommandHandler : ICommandHandler<ProductAddCommand, Product>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> Handle(ProductAddCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return product;
        }
    }
}
