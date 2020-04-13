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

        public IActionResult DeleteReservation(string reservationId)
        {

            if (reservationId == null)
            {
                return NotFound();
            }
            ShoppingCartVM cartList
              = HttpContext.Session
              .GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove =
                cartList.Reservations.FirstOrDefault(r => r.Id == reservationId);
            // db.bieren.FirstOrDefault (r => 

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
            MatchSectionVM matchSectionVM = _mapper.Map<MatchSectionVM>(matchSection);
            ReservationVM reservationVM = new ReservationVM
            {
                MatchSectionId = id,
                Price = matchSectionVM.Price,
                SectionName = matchSectionVM.Name,
                ReservationDate = matchSection.Match.MatchDate,
                NumberOfTickets = 1,
                HomeTeam = matchSectionVM.HomeTeam,
                AwayTeam = matchSectionVM.AwayTeam
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

        [Authorize]  // je moet ingelog zijn om deze action aan te spreken
        [HttpPost]
        public async Task<IActionResult> Payment(ShoppingCartVM shoppingcart)
        {
            var reservationsFromCart = shoppingcart.Reservations;
            //  opvragen ID ingelogde User
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            try
            {
                List<Reservation> reservations = _mapper.Map<List<Reservation>>(reservationsFromCart);
                foreach(var res in reservations)
                {
                    res.CustomerId = userID;
                    await _reservationService.CreateAsync(res);
                }
                return View(reservations);
            }
            catch (Exception ex)
            { }

            return View();
        }
    }
}