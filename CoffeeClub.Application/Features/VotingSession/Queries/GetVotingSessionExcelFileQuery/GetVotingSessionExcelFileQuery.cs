using MediatR;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionExcelFileQuery;

public class GetVotingSessionExcelFileQuery : IRequest<byte[]>
{
    public Guid VotingSessionId { get; set; }

}