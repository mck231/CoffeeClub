using AutoMapper;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using CoffeeClub.Application.Features.VottingSession.Commands.EditVotingSession;
using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam;
using CoffeeClub.Application.Features.User.Queries.GetUser;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionsByTeam;

namespace CoffeeClub.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coffee, CoffeeDetailsVm>();
            CreateMap<CoffeeDetailsVm, Coffee>();
            CreateMap<VotingSession, EditVotingSessionVm>().ReverseMap();

            CreateMap<User, UserDetailsVm>();
            CreateMap<UserDetailsVm, User>();

            CreateMap<VotingSession, VotingSessionVm>();
            CreateMap<VotingSessionVm, VotingSession>();
            
            CreateMap<VotingSession, VotingSessionDetailsVm>();
            CreateMap<List<VotingSession>, TeamVotingSessionsVm>()
                .ForMember(dest => dest.VotingSessions, opt => opt.MapFrom(src => src));


        }
    }
}
