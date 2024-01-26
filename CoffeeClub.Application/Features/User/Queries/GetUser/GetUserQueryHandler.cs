using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam;
using MediatR;

namespace CoffeeClub.Application.Features.User.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsVm>
{
    private readonly IAsyncRepository<Domain.Entities.User> _userRepository;
    private readonly IMapper _mapper;


    public GetUserQueryHandler(IAsyncRepository<Domain.Entities.User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserDetailsVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        
        return _mapper.Map<UserDetailsVm>(user);
    }
}