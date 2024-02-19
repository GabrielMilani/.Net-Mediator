﻿using Market.Domain.Abstractions;
using Market.Domain.Entities;
using MediatR;

namespace Market.Application.Members.Queries;

public class GetMembersQuery : IRequest<IEnumerable<Member>>
{
    public class GetMemberQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        private readonly IMemberDapperRepository _memberDapperRepository;
        public GetMemberQueryHandler(IMemberDapperRepository memberDapperRepository)
            => _memberDapperRepository = memberDapperRepository;
        public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberDapperRepository.GetMembers();
            return members;
        }
    }

}