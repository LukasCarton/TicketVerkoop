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
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ICustomerService customerService, ITeamService teamService, IMatchService matchService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _teamService = teamService;
            _matchService = matchService;
        }

        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _customerService.GetAsync(id);
            var customerVM = new CustomerVM();
            customerVM = _mapper.Map<CustomerVM>(customer);

            return View(customerVM);
        }

        public async Task<IActionResult> Teams() 
        {
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
