using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Models;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class HomeController : Controller
    {
        private ITeamService _teamService;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ITeamService teamService)
        {
            _mapper = mapper;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            // Get the id of the current user
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = await _teamService.GetAllAsync();
            List<TeamVM> listVM = _mapper.Map<List<TeamVM>>(list);
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
