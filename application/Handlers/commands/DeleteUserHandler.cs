using application.User.Commands;
using Domain.Repositories;
using MediatR;

namespace application.Handlers
{
    public partial class UpdateUserHandler
    {
        public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepositories _UserRepository;

            public DeleteUserHandler(IUserRepositories userRepository)
            {
                _UserRepository = userRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _UserRepository.DeleteUserAsync(request.Id);
                return Unit.Value;
            }
        }

    }


}
