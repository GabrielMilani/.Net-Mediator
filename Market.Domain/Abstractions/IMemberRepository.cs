using Market.Domain.Entities;

namespace Market.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMemberAll();
    Task<Member> GetMemberById(int memberId);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int memberId);
}