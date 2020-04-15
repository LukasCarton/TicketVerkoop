using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class CalendarController : Controller
    {
        private IMatchService _matchService;
        private ITeamService _teamService;
        private readonly IMapper _mapper;

        public CalendarController(IMapper mapper, IMatchService matchService, ITeamService teamService)
        {
            _matchService = matchService;
            _mapper = mapper;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _matchService.GetAllAsync();
            List<MatchVM> listVM = _mapper.Map<List<MatchVM>>(list);

            var teams = await _teamService.GetAllAsync();
            ViewBag.lstTeams = new SelectList(teams, "Id", "Name");

            return View(listVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string teamId)
        {
            if (teamId == null)
            {
                var matches = await _matchService.GetAllAsync();
                List<MatchVM> matchVMs = _mapper.Map<List<MatchVM>>(matches);

                var team = await _teamService.GetAllAsync();
                ViewBag.lstTeams = new SelectList(team, "Id", "Name");

                return View(matchVMs);
            }

            var list = await _matchService.GetAllByTeam(teamId);
            List<MatchVM> listVM = _mapper.Map<List<MatchVM>>(list);

            var teams = await _teamService.GetAllAsync();
            ViewBag.lstTeams = new SelectList(teams, "Id", "Name", teamId);

            return View(listVM);
        }
    }
}