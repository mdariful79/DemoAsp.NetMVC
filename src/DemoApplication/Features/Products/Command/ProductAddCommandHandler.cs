using Cortex.Mediator.Commands;
using Demo.Domain.Utilities;
using DemoApplication.Contracts;
using DemoApplication.Exceptions;
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
            var isDuplicateName = await _unitOfWork.ProductRepository.IsDuplicateProductName(command.Name, cancellationToken);

            if (!isDuplicateName)
            {
                var product = _mapper.Map<Product>(command);
                product.Id = IdentityGenerator.NewSequentialGuid();

                await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);
                await _unitOfWork.SaveAsync();

                return product;
            }
            else
                throw new DuplicateDataException("Product name is duplicate");
        }
    }
}