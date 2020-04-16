using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class MatchController : Controller
    {
        private IMatchService _matchService;
        private ITeamService _teamService;
        private readonly IMapper _mapper;

        public MatchController(IMapper mapper, IMatchService matchService, ITeamService teamService)
        {
            _mapper = mapper;
            _matchService = matchService;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index(string team)
        {
            var currentTeam = await _teamService.GetAsync(team);
            var homeTeamId = currentTeam.Id;


            var list = await _matchService.GetAllByHomeTeam(homeTeamId);
            List<MatchVM> matchVMs = _mapper.Map<List<MatchVM>>(list);
            TeamWithMatchesVM listVM = new TeamWithMatchesVM { TeamName = currentTeam.Name, StadiumId = currentTeam.StadiumId, MatchVMs = matchVMs };

            return View(listVM);
        }
    }
}