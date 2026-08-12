using MediatR;

public class UpdateProfileCommand : IRequest<UpdateProfileResponse>
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;

    public string Phone { get; set; } = default!;
}

public class UpdateProfileResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = default!;
}