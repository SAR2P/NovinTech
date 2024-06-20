using application.User.Queries;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Handlers.Queries
{
    public class GetAllUSersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserClass>>
    {
        private readonly IUserRepositories _UserRepository;

        public GetAllUSersHandler(IUserRepositories UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<IEnumerable<UserClass>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetAllUSersAsync();
        }
    }


}
