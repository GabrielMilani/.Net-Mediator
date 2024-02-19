using Market.Domain.Abstractions;
using Market.Infrastructure.Context;

namespace Market.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepository;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
        => _context = context;

    public IMemberRepository MemberRepository
        => _memberRepository = _memberRepository ?? new MemberRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}