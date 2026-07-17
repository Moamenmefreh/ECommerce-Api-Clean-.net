using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Categories.CategoryCommands.DeleteCategory;

public class DeleteHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<DeleteCommands, DeleteResponse>
{
    public async Task<DeleteResponse> Handle(DeleteCommands request, CancellationToken cancellationToken)
    {
        var category =await categoryRepository.GetById(request.CategoryId);

        if (category == null) 
        {
            return new DeleteResponse
            {
                Message="Category Not Found",
                IsSuccess=false


            };
        }
        categoryRepository.Delete(category);
        return new DeleteResponse
        {
              Message="Category Deleted Successfully",
              IsSuccess=true
        };
    }
}
