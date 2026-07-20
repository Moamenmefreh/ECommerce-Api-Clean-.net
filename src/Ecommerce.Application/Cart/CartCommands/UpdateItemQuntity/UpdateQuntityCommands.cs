using MediatR;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;

public class UpdateQuntityCommands:IRequest<UpdateQuntityResponse>
{
    [JsonIgnore]
    public Guid ItemId { get; set; }
    public int Quntity { get; set; }

}
public class UpdateQuntityResponse
{
    public Guid ItemId { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}