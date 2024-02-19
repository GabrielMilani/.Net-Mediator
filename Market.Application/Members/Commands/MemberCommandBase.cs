using Market.Domain.Entities;
using MediatR;

namespace Market.Application.Members.Commands;

public abstract class MemberCommandBase : IRequest<Member>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}