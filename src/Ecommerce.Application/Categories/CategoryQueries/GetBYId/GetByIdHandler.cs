using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Categories.CategoryQueries.GetBYId;

public class GetByIdHandler(ICategoryRepository categoryRepository) :
    IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
       if(request == null)
            throw new ArgumentNullException(nameof(request));
        try
        {
            var category1 = await categoryRepository.GetById(request.CategoryId);
            if (category1 != null)
            {
                return new GetByIdResponse
                {
                    CategoryId = category1.Id,
                    NameCategory = category1.Name,
                    Description = category1.Description,

                };
            }
            return new GetByIdResponse
            {
                CategoryId = request.CategoryId,
                NameCategory = "Not Found",
                Description = "I`m Sorry But This Product I Dont Found"
            };
        }
        catch (Exception ex)
        {

          throw new ArgumentException(ex.Message);
        }
    }
}
