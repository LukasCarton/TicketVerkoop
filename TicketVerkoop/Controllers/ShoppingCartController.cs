using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Extensions;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class ShoppingCartController : Controller
    {

        private IReservationService _reservationService;
        private IMatchSectionService _matchSectionService;
        private ISeasonService _seasonService;
        private ISubscriptionService _subscriptionService;
        private ISectionService _sectionService;
        private ITeamService _teamService;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;
        private ICustomerService _customerService;
        private readonly IMapper _mapper;

        public ShoppingCartController(
            IReservationService reservationService,
            IMatchSectionService matchSectionService,
            ISeasonService seasonService,
            ISubscriptionService subscriptionService,
            ISectionService sectionSerivce,
            ITeamService teamService,
            IEmailSender emailSender,
            UserManager<IdentityUser> userManager,
            ICustomerService customerService,
            IMapper mapper)
        {
            _reservationService = reservationService;
            _matchSectionService = matchSectionService;
            _seasonService = seasonService;
            _subscriptionService = subscriptionService;
            _sectionService = sectionSerivce;
            _teamService = teamService;
            _emailSender = emailSender;
            _userManager = userManager;
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ShoppingCartVM cartList =
              HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            return View(cartList);
        }

        public IActionResult DeleteReservation(string matchSectionId)
        {

            if (matchSectionId == null)
            {
                return NotFound();
            }
            ShoppingCartVM cartList
              = HttpContext.Session
              .GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove =
                cartList.Reservations.FirstOrDefault(r => r.MatchSectionId == matchSectionId);

            if (itemToRemove != null)
            {
                cartList.Reservations.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);

            }

            return View("index", cartList);

        }

        public IActionResult DeleteSubscription(string teamId)
        {
            if (teamId == null)
            {
                return NotFound();
            }
            ShoppingCartVM cartList
              = HttpContext.Session
              .GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove =
                cartList.Subscriptions.FirstOrDefault(r => r.TeamId == teamId);

            if (itemToRemove != null)
            {
                cartList.Subscriptions.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);

            }

            return View("index", cartList);

        }
        [Authorize]
        public async Task<IActionResult> Select(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MatchSection matchSection = await _matchSectionService.FindById(id);
            ReservationVM reservationVM = new ReservationVM
            {
                MatchId = matchSection.Match.Id,
                ReservationDate = DateTime.Now,
                NumberOfTickets = 1,
                Price = matchSection.Match.BasePriceTicket * matchSection.Section.PriceFactor,
                SectionName = matchSection.Section.Name,
                MatchSectionId = id,
                HomeTeam = matchSection.Match.HomeTeam.Name,
                AwayTeam = matchSection.Match.AwayTeam.Name,
                MatchDate = matchSection.Match.MatchDate.Date
            };

            ShoppingCartVM shopping;


            // var objComplex = HttpContext.Session.GetObject<ShoppingCartVM>("ComplexObject");
            if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
            {
                shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            }
            else
            {
                shopping = new ShoppingCartVM();
                shopping.Reservations = new List<ReservationVM>();
                shopping.Subscriptions = new List<SubscriptionCartVM>();
            }
            shopping.Reservations.Add(reservationVM);
            HttpContext.Session.SetObject("ShoppingCart", shopping);

            return RedirectToAction("Index", "ShoppingCart");

        }
        [Authorize]
        public async Task<IActionResult> SelectSubscription(string id,string teamName)
        {
            if (id == null || teamName == null)
            {
                return NotFound();
            }
            Section section = await _sectionService.FindById(id);
            var season = await _seasonService.GetNextSeasonAsync();
            var team = await _teamService.GetAsync(teamName);
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            SubscriptionCartVM subscriptionCartVM = new SubscriptionCartVM
            {
                SeasonStartDate = season.StartDate,
                SeasonEndDate = season.EndDate,
                SectionName = section.Name,
                TeamName = team.Name,
                SeasonId = season.Id,
                Price = section.PriceFactor * team.SubscriptionPrice,
                CustomerId = userID,
                TeamId = team.Id,
                SectionId = section.Id,
            };
            ShoppingCartVM shopping;

            // var objComplex = HttpContext.Session.GetObject<ShoppingCartVM>("ComplexObject");
            if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
            {
                shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            }
            else
            {
                shopping = new ShoppingCartVM();
                shopping.Reservations = new List<ReservationVM>();
                shopping.Subscriptions = new List<SubscriptionCartVM>();

            }
            shopping.Subscriptions.Add(subscriptionCartVM);
            HttpContext.Session.SetObject("ShoppingCart", shopping);

            return RedirectToAction("Index", "ShoppingCart");
        }

        [Authorize]  // je moet ingelogd zijn om deze action aan te spreken
        [HttpPost]
        public async Task<IActionResult> Payment(ShoppingCartVM shoppingcart)
        {
            var reservationsFromCart = shoppingcart.Reservations;
            var subscriptionsFromCart = shoppingcart.Subscriptions;
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (reservationsFromCart != null && reservationsFromCart.Count != 0)
            {
                var validations = await IsValidReservations(userID, reservationsFromCart);
                if (!validations[0])
                {
                    ModelState.AddModelError("error", "U kunt maar 10 tickets per match kopen.");
                    return View("Index", shoppingcart);
                }
                if (!validations[1])
                {
                    ModelState.AddModelError("error", "U kunt geen 2 verschillende matchen op dezelfde dag kopen.");
                    return View("Index", shoppingcart);
                }
                if (!validations[2])
                {
                    ModelState.AddModelError("error", "Uw aantal tickets overschrijdt het aantal beschikbare plaatsen.");
                    return View("Index", shoppingcart);
                }

                List<Reservation> reservations = _mapper.Map<List<Reservation>>(reservationsFromCart);
                for(var i = 0; i < reservationsFromCart.Count;i++)
                {
                    reservations[i].CustomerId = userID;
                    shoppingcart.Reservations[i].Price = shoppingcart.Reservations[i].Price * shoppingcart.Reservations[i].NumberOfTickets;
                    reservations[i].Price = shoppingcart.Reservations[i].Price;
                    await _reservationService.CreateAsync(reservations[i]);
                }
            }
            if (subscriptionsFromCart != null && subscriptionsFromCart.Count != 0)
            {
                List<Subscription> subscriptions = _mapper.Map<List<Subscription>>(subscriptionsFromCart);
                foreach (var sub in subscriptions)
                {
                    sub.CustomerId = userID;
                    await _subscriptionService.CreateAsync(sub);
                }
            }
            
            var user = await _userManager.FindByIdAsync(userID);
            var useremail = user.Email;
            var customer = await _customerService.GetAsync(userID);
            await _emailSender.SendEmailAsync(
                    useremail,
                    "Betaling Ontvangen",
                    BuildVoucherMessage(shoppingcart, customer.LastName + " " + customer.FirstName)
                    );

            HttpContext.Session.SetObject("ShoppingCart", null);
            return View(shoppingcart);
        }
        private string BuildVoucherMessage(ShoppingCartVM shoppingCart, string name)
        {
            string message = 
            $@"Beste {name} <br/>
            We hebben uw betaling geregistreerd. <br/>";
            if(shoppingCart.Reservations != null && shoppingCart.Reservations.Count != 0)
            {
                foreach (var reservation in shoppingCart.Reservations)
                {
                    message += "RESERVATION <br/>";
                    message += $@"Match Datum: {reservation.MatchDate} <br/>";
                    message += $@"Thuis Ploeg: {reservation.HomeTeam} <br/>";
                    message += $@"Uit Ploeg: {reservation.AwayTeam} <br/>";
                    message += $@"Tickets: {reservation.NumberOfTickets} <br/>";
                    message += $@"Vak: {reservation.SectionName} <br/>";
                    message += $@"Prijs: {reservation.Price.ToString("C2")} <br/>";
                    message += $@"Reservatie datum: {reservation.ReservationDate} <br/>";
                    message += $@"Match datum: {reservation.MatchDate} <br/>";
                    message += "------<br/>";
                }
            }
            if (shoppingCart.Subscriptions != null && shoppingCart.Subscriptions.Count != 0)
            {
                foreach (var subscription in shoppingCart.Subscriptions)
                {
                    message += "SUBSCRIPTION <br/>";
                    message += $@"Start Datum: {subscription.SeasonStartDate} <br/>";
                    message += $@"Eind Datum: {subscription.SeasonEndDate} <br/>";
                    message += $@"Team: {subscription.TeamName} <br/>";
                    message += $@"Vak: {subscription.SectionName} <br/>";
                    message += $@"Prijs: {subscription.Price.ToString("C2")} <br/>";
                    message += "------<br/>";
                }
            }
            return message;
        }

        private async Task<List<bool>> IsValidReservations(string customerId,List<ReservationVM> reservations)
        {
            List<bool> validations = new List<bool>();
            validations.Add(true);
            validations.Add(true);
            validations.Add(true);
            foreach (var res in reservations)
            {
                var matchSection = await _matchSectionService.FindById(res.MatchId);
                var ticketsinDb = await _reservationService.GetNumberOfAllReservationsForMatchFromCustomerAsync(customerId, res.MatchId);
                if (res.NumberOfTickets + ticketsinDb > 10)
                {
                    validations[0] = false;
                }
                if(!await _reservationService.HasNoOtherMatchOnDay(customerId, res.MatchDate, res.MatchId)){
                    validations[1] = false;
                }
                if(matchSection.OccupiedReservationSeats + res.NumberOfTickets + matchSection.Section.OccupiedSubscriptionSeats > matchSection.Section.Capacity)
                {
                    validations[2] = false;
                }
            }
            return validations;
        }
    }
    
}