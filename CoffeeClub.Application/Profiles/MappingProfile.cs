using AutoMapper;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using CoffeeClub.Application.Features.VottingSession.Commands.EditVotingSession;
using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coffee, CoffeeDetailsVm>();
            CreateMap<CoffeeDetailsVm, Coffee>();
            CreateMap<VotingSession, EditVotingSessionVm>().ReverseMap();


        }
    }
}
