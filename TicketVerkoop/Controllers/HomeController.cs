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
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ICustomerService customerService, ITeamService teamService, IMatchService matchService, ISectionService sectionService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _teamService = teamService;
            _matchService = matchService;
            _sectionService = sectionService;
        }

        public async Task<IActionResult> Index()
        {
            // Get the id of the current user
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var list = await _teamService.GetAllAsync();
            List<TeamVM> listVM = _mapper.Map<List<TeamVM>>(list);
            return View(listVM);
        }

        public async Task<IActionResult> Matches(string team)
        {
            var currentTeam = await _teamService.GetAsync(team);
            var homeTeamId = currentTeam.Id;


            var list = await _matchService.GetAllByHomeTeam(homeTeamId);
            List<MatchVM> listVM = _mapper.Map<List<MatchVM>>(list);

            return View(listVM);
        }

        public async Task<IActionResult> Sections(string match)
        {
            var currentMatch = await _matchService.GetAsync(match);
            var basePrice = currentMatch.BasePriceTicket;
            var stadiumId = currentMatch.StadiumId;
            var sections = await _sectionService.GetAllByStadiumAsync(stadiumId);
            List<SectionVM> listVM = _mapper.Map<List<SectionVM>>(sections);
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
