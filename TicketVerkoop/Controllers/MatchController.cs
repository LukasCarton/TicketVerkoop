using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _matchService.GetAllAsync();
            List<MatchVM> listVM = _mapper.Map<List<MatchVM>>(list);

            return View(listVM);
        }
    }
}