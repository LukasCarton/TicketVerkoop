using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class StadiumController : Controller
    {
        private IStadiumService _stadiumService;
        private readonly IMapper _mapper;

        public StadiumController(IMapper mapper, IStadiumService stadiumService)
        {
            _mapper = mapper;
            _stadiumService = stadiumService;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _stadiumService.GetAllAsync();
            List<StadiumVM> listVM = _mapper.Map<List<StadiumVM>>(list);

            return View(listVM);
        }
    }
}