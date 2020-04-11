using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Service.Interfaces;

namespace TicketVerkoop.Controllers
{
    public class SubscriptionController : Controller
    {
        private ISubscriptionService _subscriptionService;

        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Subscription s = new Subscription
            {
                SeasonId = "1",
                TeamId ="1",
                CustomerId = id,
                SectionId = "1"
            };
            await _subscriptionService.CreateAsync(s);
            return View(s);
        }

        public async Task<IActionResult> ListSubscriptions()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var subscriptions = await _subscriptionService.GetAllCustomerSubscriptionAsync(id);
            return View(subscriptions);
        }

        public string Id { get; set; }
        public string SeasonId { get; set; }
        public string TeamId { get; set; }
        public string SectionId { get; set; }
        public string CustomerId { get; set; }
    }
}