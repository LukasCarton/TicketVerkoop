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
        }
    }
}
