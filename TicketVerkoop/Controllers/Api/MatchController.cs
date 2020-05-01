using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchController(IMapper mapper, IMatchService matchService)
        {
            _mapper = mapper;
            _matchService = matchService;
        }


        /// <summary>
        /// Gets a list of all the matches.
        /// </summary>
        /// <returns>The list of matches.</returns>
        [HttpGet]
        public async Task<IEnumerable<MatchApiVM>> Get()
        {
            var list = await _matchService.GetAllAsync();
            return _mapper.Map<List<MatchApiVM>>(list);
        }

        /// <summary>
        /// Gets a list of matches for one team
        /// </summary>
        /// <param name="id">The id of the team</param>
        /// <returns>The list of matches.</returns>
        [HttpGet("{id}", Name ="Get")]
        public async Task<IEnumerable<MatchApiVM>> Get(string id)
        {
            var list = await _matchService.GetAllByTeam(id);
            return _mapper.Map<List<MatchApiVM>>(list);
        }
    }
}