using CoffeeClub.Application.Contracts.Infrastructure;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Domain.Entities;
using MediatR;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionExcelFileQuery;

public class GetVotingSessionExcelFileQueryHandler : IRequestHandler<GetVotingSessionExcelFileQuery, byte[]>
{
    private readonly IVotingSessionRepository _votingSessionRepository;
    private readonly ICsvExporter<VoteSummaryDto> _csvExporter;

    public GetVotingSessionExcelFileQueryHandler(IVotingSessionRepository votingSessionRepository, ICsvExporter<VoteSummaryDto> csvExporter)
    {
        _votingSessionRepository = votingSessionRepository;
        _csvExporter = csvExporter;
    }
    public async Task<byte[]> Handle(GetVotingSessionExcelFileQuery request, CancellationToken cancellationToken)
    {
        var votingSession = await _votingSessionRepository.GetVotingSessionWithDetails(request.VotingSessionId);

        if (votingSession == null)
        {
            throw new NotFoundException(nameof(VotingSession), request.VotingSessionId);
        }

        var voteSummaries = votingSession.Votes.Select(vote => new VoteSummaryDto
        {
            Name = vote.UserId.ToString(),
            Voted = true 
        }).ToList();

        var fileContent = _csvExporter.ExportJsonDataToCsv(voteSummaries);
        return fileContent;
    }
}