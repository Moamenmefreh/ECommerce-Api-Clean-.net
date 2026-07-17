using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Categories.CategoryCommands.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
       
        if(request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            var product = Category.Create(request.name, request.description, request.imageUrl);

           categoryRepository.Add(product);
            return new CreateCategoryResponse
            {
                Message = "Category Created Successfully",
                IsSuccess = true,
            };
        }
        catch (Exception ex) {
            throw new ArgumentException(ex.Message, nameof(request));
           
        }
    }
}