﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketVerkoop.Repository
{
    public class ReservationDAO : IReservationDAO
    {

        private readonly TicketVerkoopDbContext _dbContext;

        public ReservationDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task CreateAsync(Reservation entity)
        {
            var reservation = new Reservation
            {
                ReservationDate = entity.ReservationDate,
                NumberOfTickets = entity.NumberOfTickets,
                CustomerId = entity.CustomerId,
                MatchSectionId = entity.MatchSectionId,
                Price = entity.Price
            };
            _dbContext.Entry(reservation).State = EntityState.Added;
            var matchSection = await _dbContext.MatchSections.FirstOrDefaultAsync(s => s.Id == entity.MatchSectionId);
            matchSection.OccupiedReservationSeats += reservation.NumberOfTickets;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Reservation> FindById(string Id)
        {
            try
            {
                return await _dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsFromCustomerAsync(string customerId)
        {
            try
            {
                return await _dbContext.Reservations.Where(r => r.CustomerId == customerId)
                    .Where(r => r.ReservationDate >= DateTime.Today)
                    .Include(r => r.Customer)
                    .Include(r => r.MatchSection)
                    .Include(r => r.MatchSection.Section)
                    .Include(r => r.MatchSection.Match.HomeTeam)
                    .Include(r => r.MatchSection.Match.AwayTeam)
                    .ToListAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetNumberOfAllReservationsForMatchFromCustomerAsync(string customerId, string matchId)
        {
            return await _dbContext.Reservations
                .Where(r => r.CustomerId == customerId && r.MatchSection.MatchId == matchId)
                .SumAsync(r => r.NumberOfTickets);
        }

        public async Task<bool> HasNoOtherMatchOnDay(string customerId, DateTime matchDate,string matchId)
        {
            var reservations = await _dbContext.Reservations
                .Include(r => r.MatchSection)
                .Include(r => r.MatchSection.Section)
                .Include(r => r.MatchSection.Match)
                .Where(r => r.CustomerId == customerId && r.MatchSection.Match.MatchDate.Date.Equals(matchDate.Date))
                .ToListAsync();
            if (reservations.Count() == 0)
            {
                return true;
            }
            else
            {
                var total = 0;
                foreach(var reservation in reservations)
                {
                    if (reservation.MatchSection.Match.Id.Equals(matchId))
                    {
                        total++;
                    }
                }
                return total == reservations.Count;
            }
            
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            var matchSection = await _dbContext.MatchSections.FirstOrDefaultAsync(s => s.Id == reservation.MatchSectionId);
            matchSection.OccupiedReservationSeats -= reservation.NumberOfTickets;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
