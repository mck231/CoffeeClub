using System;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Application.Contracts.Persistence
{
	public interface IVotingSession : IAsyncRepository<VotingSession>
	{
		
	}
}

