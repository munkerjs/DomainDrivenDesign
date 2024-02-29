using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProduct
{
    internal sealed class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync(cancellationToken);
        }
    }
}
