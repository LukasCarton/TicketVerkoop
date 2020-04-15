using AutoMapper;
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
                .ForMember(dest => dest.StadiumNaam, opts => opts.MapFrom(src => src.HomeTeam.Stadium.Name))
                .ForMember(dest => dest.SeasonStartDate, opts => opts.MapFrom(src => src.Season.StartDate))
                .ForMember(dest => dest.SeasonEndDate, opts => opts.MapFrom(src => src.Season.EndDate))
                .ForMember(dest => dest.HomeTeamNaam, opts => opts.MapFrom(src => src.HomeTeam.Name))
                .ForMember(dest => dest.AwayTeamNaam, opts => opts.MapFrom(src => src.AwayTeam.Name));

            CreateMap<Reservation, ReservationVM>()
                .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.MatchSection.Section.Name))
                .ForMember(dest => dest.HomeTeam, opts => opts.MapFrom(src => src.MatchSection.Match.HomeTeam.Name))
                .ForMember(dest => dest.MatchDate, opts => opts.MapFrom(src => src.MatchSection.Match.MatchDate))
                .ForMember(dest => dest.AwayTeam, opts => opts.MapFrom(src => src.MatchSection.Match.AwayTeam.Name));


            CreateMap<Subscription, SubscriptionVM>()
                .ForMember(dest => dest.SeasonStartDate, opts => opts.MapFrom(src => src.Season.StartDate))
                .ForMember(dest => dest.SeasonEndDate, opts => opts.MapFrom(src => src.Season.EndDate))
                .ForMember(dest => dest.CustomerName, opts => opts.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.TeamName, opts => opts.MapFrom(src => src.Team.Name));

            CreateMap<Section, SectionVM>()
                .ForMember(dest => dest.AvailablePlaces, opts => opts.MapFrom(src => src.Capacity - src.OccupiedSubscriptionSeats))
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.PriceFactor));

            CreateMap<MatchSection, MatchSectionVM>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Section.Name))
                .ForMember(dest => dest.AvailablePlaces, opts => opts.MapFrom(src => src.Section.Capacity - src.Section.OccupiedSubscriptionSeats - src.OccupiedReservationSeats))
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.Match.BasePriceTicket * src.Section.PriceFactor))
                .ForMember(dest => dest.Ring, opts => opts.MapFrom(src => src.Section.Ring))
                .ForMember(dest => dest.HomeTeam, opts => opts.MapFrom(src => src.Match.HomeTeam.Name))
                .ForMember(dest => dest.AwayTeam, opts => opts.MapFrom(src => src.Match.AwayTeam.Name));

            CreateMap<ReservationVM, Reservation>();
            CreateMap<SubscriptionCartVM, Subscription>();

        }
    }
}
