using application.User.Queries;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace application.Handlers.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserClass>
    {

        private readonly IUserRepositories _UserRepository;

        public GetUserByIdHandler(IUserRepositories userRepositories)
        {
            _UserRepository = userRepositories;
        }
        public async Task<UserClass> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetUserByIdAsync(request.Id);
        }
    }


}
