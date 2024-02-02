using CoffeeClub.Application.Contracts.Infrastructure;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Models;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Application.Services;

public class VotingService : IVotingService
{
    private readonly IVotingSessionRepository _votingSessionRepository;
    private readonly IAsyncRepository<Domain.Entities.User> _userRepository;
    private readonly ICoffeeRepository _coffeeRepository;
    private readonly IAsyncRepository<Domain.Entities.Vote> _voteRepository;

    public VotingService(IVotingSessionRepository votingSessionRepository,
        IAsyncRepository<Domain.Entities.User> userRepository, ICoffeeRepository coffeeRepository,
        IAsyncRepository<Domain.Entities.Vote> voteRepository)
    {
        _votingSessionRepository = votingSessionRepository;
        _userRepository = userRepository;
        _coffeeRepository = coffeeRepository;
        _voteRepository = voteRepository;
    }

    public async Task ProcessVote(Guid votingSessionId, Guid coffeeId, Guid userId)
    {
        var votingSession = await _votingSessionRepository.GetVotingSessionWithVotes(votingSessionId);
        ValidateVotingSession(votingSession, userId);

        var coffee = await _coffeeRepository.GetByIdAsync(coffeeId);
        if (coffee == null)
        {
            throw new NotFoundException(nameof(coffee),coffeeId);
        }

        var vote = new Vote
        {
            UserId = userId,
            CoffeeId = coffeeId,
            VotingSessionId = votingSessionId
        };

        await _voteRepository.AddAsync(vote);
    }

    public async Task<List<CoffeeVote>> GetUpdatedVotes(Guid votingSessionId)
    {
        return await _votingSessionRepository.GetVoteCountsBySessionId(votingSessionId);

    }

    private void ValidateVotingSession(VotingSession votingSession, Guid userId)
    {
        if (votingSession == null)
        {
            throw new Exception("Voting session not found.");
        }

        if (DateTime.Now < votingSession.StartDate || DateTime.Now > votingSession.EndDate)
        {
            throw new Exception("Voting session is not active.");
        }

        if (votingSession.Votes.Any(v => v.UserId == userId))
        {
            throw new Exception("User has already voted in this session.");
        }
    }

}