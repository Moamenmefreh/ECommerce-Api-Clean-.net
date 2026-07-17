using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Categories.CategoryCommands.UpdateCategory;

public class UpdateHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<UpdateCommands, UpdateResponse>
{
    public async Task<UpdateResponse> Handle(UpdateCommands request, CancellationToken cancellationToken)
    {
        var category=await categoryRepository.GetById(request.Id);

        if (category == null) {

            return new UpdateResponse
            {
                Message = "Not Found",
                IsSuccess = false
            };
        }
        try
        {
            category.Update(request.Name, request.Description!, request.ImageUrl!);

            categoryRepository.Update(category);
            return new UpdateResponse
            {
                Message = "Updated Successfully",
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new UpdateResponse { Message = ex.Message ,
            IsSuccess = false
            };

        }
    }
}
