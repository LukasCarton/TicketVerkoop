﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //CreateMap<TSource, TDestination>;
            CreateMap<Customer, CustomerVM>();

            CreateMap<Stadium, StadiumVM>();

            CreateMap<Team, TeamVM>();

            CreateMap<Match, MatchVM>()
                .ForMember(dest => dest.StadiumNaam, opts => opts.MapFrom(src => src.Stadium.Name))
                .ForMember(dest => dest.SeasonStartDate, opts => opts.MapFrom(src => src.Season.StartDate))
                .ForMember(dest => dest.SeasonEndDate, opts => opts.MapFrom(src => src.Season.EndDate))
                .ForMember(dest => dest.HomeTeamNaam, opts => opts.MapFrom(src => src.HomeTeam.Name))
                .ForMember(dest => dest.AwayTeamNaam, opts => opts.MapFrom(src => src.AwayTeam.Name));

            CreateMap<Reservation, ReservationVM>()
                .ForMember(dest => dest.CustomerName, opts => opts.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Section.Name))
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.Match.BasePriceTicket));
            CreateMap<Subscription, SubscriptionVM>()
                .ForMember(dest => dest.SeasonStartDate, opts => opts.MapFrom(src => src.Season.StartDate))
                .ForMember(dest => dest.SeasonEndDate, opts => opts.MapFrom(src => src.Season.EndDate))
                .ForMember(dest => dest.CustomerName, opts => opts.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.TeamName, opts => opts.MapFrom(src => src.Team.Name));
        }
    }
}
