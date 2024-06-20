using application.User.Commands;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace application.Handlers.commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepositories _UserRepository;
        public CreateUserHandler(IUserRepositories userRepositories)
        {
            _UserRepository = userRepositories;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserClass()
            {
                FullName = request.FullName,
                Age = request.Age
            };

            await _UserRepository.AddUserAsync(user);

            return Unit.Value;

        }
    }


}
