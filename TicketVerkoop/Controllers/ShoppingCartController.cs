using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        public ShoppingCartController(IReservationService reservationService, IMatchSectionService matchSectionService, IMapper mapper)
        {
            _reservationService = reservationService;
            _matchSectionService = matchSectionService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ShoppingCartVM cartList =
              HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            // call SessionID
            //var SessionId =  HttpContext.Session.Id;

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

        public IActionResult DeleteSubscription(string subscriptionId)
        {

            if (subscriptionId == null)
            {
                return NotFound();
            }
            ShoppingCartVM cartList
              = HttpContext.Session
              .GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove =
                cartList.Subscriptions.FirstOrDefault(r => r.Id == subscriptionId);
            // db.bieren.FirstOrDefault (r => 

            if (itemToRemove != null)
            {
                cartList.Subscriptions.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);

            }

            return View("index", cartList);

        }

        public async Task<IActionResult> Select(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MatchSection matchSection = await _matchSectionService.FindById(id);
            ReservationVM reservationVM = new ReservationVM
            {
                ReservationDate = DateTime.Now,
                NumberOfTickets = 1,
                Price = matchSection.Match.BasePriceTicket,
                SectionName = matchSection.Section.Name,
                MatchSectionId = id,
                HomeTeam = matchSection.Match.HomeTeam.Name,
                AwayTeam = matchSection.Match.AwayTeam.Name
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
            }
            shopping.Reservations.Add(reservationVM);

            
            HttpContext.Session.SetObject("ShoppingCart", shopping);


            //  Session["ShoppingCart"] = shopping;

            return RedirectToAction("Index", "ShoppingCart");

        }

        [Authorize]  // je moet ingelogd zijn om deze action aan te spreken
        [HttpPost]
        public async Task<IActionResult> Payment(ShoppingCartVM shoppingcart)
        {
            var reservationsFromCart = shoppingcart.Reservations;
            //  opvragen ID ingelogde User
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(reservationsFromCart == null || reservationsFromCart.Count == 0)
            {
                return NotFound();
            }

            try
            {
                List<Reservation> reservations = _mapper.Map<List<Reservation>>(reservationsFromCart);
                foreach(var res in reservations)
                {
                    res.CustomerId = userID;
                    await _reservationService.CreateAsync(res);
                }
                HttpContext.Session.SetObject("ShoppingCart", null);
                return View(reservationsFromCart);
            }
            catch (Exception ex)
            { }

            return View();
        }
    }
}