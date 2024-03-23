using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Users.Queries.GetUser;
public class GetUserQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        await _userRepository.GetByIdAsync(request.Id);
        var response = _mapper.Map<GetUserResponse>(request);
        return response;

    }
}
