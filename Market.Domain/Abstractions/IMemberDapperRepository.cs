using Market.Domain.Entities;

namespace Market.Domain.Abstractions;

public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member?> GetMemberById(int memberId);
}