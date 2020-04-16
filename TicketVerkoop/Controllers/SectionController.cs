using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class SectionController : Controller
    {
        private IMatchSectionService _matchSectionService;
        private readonly IMapper _mapper;

        public SectionController(IMapper mapper, IMatchSectionService matchSectionService)
        {
            _mapper = mapper;
            _matchSectionService = matchSectionService;
        }

        public async Task<IActionResult> Index(string match)
        {
            var matchSections = await _matchSectionService.GetAllByMatchAsync(match);
            List<MatchSectionVM> listVM = _mapper.Map<List<MatchSectionVM>>(matchSections);
            return View(listVM);
        }
    }
}