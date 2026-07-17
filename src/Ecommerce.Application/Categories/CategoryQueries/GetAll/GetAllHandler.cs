using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Categories.CategoryQueries.GetAll;

public class GetAllHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetAllQueries, List<GetAllResponse>>
{
    public async Task<List<GetAllResponse>> Handle(GetAllQueries request, CancellationToken cancellationToken)
    {
        var categorylist =await categoryRepository.GetAll(request.CategoryName,request.pageNumber,request.pageSize);
        
            return categorylist.Select(x => new GetAllResponse
            {
                CategoryId=x.Id,
                Name=x.Name,
                Description=x.Description,
                CreatedDate=x.CreatedAt
            }).ToList();
       
    }
}
