using application.User.Commands;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace application.Handlers
{
    public partial class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepositories _UserRepository;

        public UpdateUserHandler(IUserRepositories userRepositories)
        {
            _UserRepository =(userRepositories);
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserClass()
            {
                Id = request.Id,
                FullName = request.FullName,
                Age = request.Age
            };

            await _UserRepository.UpdateUserAsync(user);

            return Unit.Value;
        }

    }


}
