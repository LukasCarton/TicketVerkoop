using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class SubscriptionController : Controller
    {
        private ISubscriptionService _subscriptionService;
        private ITeamService _teamService;
        private ISectionService _sectionService;
        private ISeasonService _seasonService;

        private readonly IMapper _mapper;

        public SubscriptionController(IMapper mapper, 
            ISubscriptionService subscriptionService, 
            ITeamService teamService, 
            ISectionService sectionService,
            ISeasonService seasonService)
        {
            _mapper = mapper;
            _subscriptionService = subscriptionService;
            _teamService = teamService;
            _sectionService = sectionService;
            _seasonService = seasonService;

        }

        public async Task<IActionResult> Index(string team)
        {
            var currentTeam = await _teamService.GetAsync(team);
            var sections = await _sectionService.GetAllByStadiumAsync(currentTeam.StadiumId);
            var season = await _seasonService.GetNextSeasonAsync();

            List<SectionVM> sectionVMs = _mapper.Map<List<SectionVM>>(sections);

            foreach (var item in sectionVMs)
            {
                item.Price = item.Price * currentTeam.SubscriptionPrice;
            }

            SubscriptionSectionVM listVM = new SubscriptionSectionVM
            {
                TeamName = currentTeam.Name,
                TeamLogo = currentTeam.Logo,
                StartDate = season.StartDate,
                EndDate = season.EndDate,
                SectionVMs = sectionVMs
            };

            return View(listVM);
        }
    }
}