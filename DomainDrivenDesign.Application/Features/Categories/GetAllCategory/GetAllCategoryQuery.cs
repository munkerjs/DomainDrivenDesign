using DomainDrivenDesign.Domain.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Categories.GetAllCategories
{
    public sealed record class GetAllCategoryQuery() : IRequest<List<Category>>;

    internal sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllAsync(cancellationToken);
        }
    }
}
