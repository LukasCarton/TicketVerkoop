using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Models;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;
        private ITeamService _teamService;
        private IMatchService _matchService;
        private ISectionService _sectionService;
        private IMatchSectionService _matchSectionService;
        private ISeasonService _seasonService;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper,
            ICustomerService customerService,
            ITeamService teamService,
            IMatchService matchService,
            ISectionService sectionService,
            IMatchSectionService matchSectionService,
            ISeasonService seasonService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _teamService = teamService;
            _matchService = matchService;
            _sectionService = sectionService;
            _matchSectionService = matchSectionService;
            _seasonService = seasonService;
        }

        public async Task<IActionResult> Index()
        {
            // Get the id of the current user
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = await _teamService.GetAllAsync();
            List<TeamVM> listVM = _mapper.Map<List<TeamVM>>(list);
            return View(listVM);
        }

        public async Task<IActionResult> Matches(string team)
        {
            var currentTeam = await _teamService.GetAsync(team);
            var homeTeamId = currentTeam.Id;


            var list = await _matchService.GetAllByHomeTeam(homeTeamId);
            List<MatchVM> matchVMs = _mapper.Map<List<MatchVM>>(list);
            TeamWithMatchesVM listVM = new TeamWithMatchesVM { TeamName = currentTeam.Name, MatchVMs = matchVMs };

            return View(listVM);
        }


        public async Task<IActionResult> Sections(string match)
        {
            var matchSections = await _matchSectionService.GetAllByMatchAsync(match);
            List<MatchSectionVM> listVM = _mapper.Map<List<MatchSectionVM>>(matchSections);
            return View(listVM);
        }

        public async Task<IActionResult> Subscriptions(string team)
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


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
