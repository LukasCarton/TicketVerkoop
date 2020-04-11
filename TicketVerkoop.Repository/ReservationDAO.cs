using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
                MatchId = entity.MatchId,
                SectionId = entity.SectionId
            };
            _dbContext.Entry(reservation).State = EntityState.Added;
            var section = await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == entity.SectionId);
            section.OccupiedReservationSeats++;

            try
            {
                await _dbContext.SaveChangesAsync();
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
                    .Include(r => r.Customer)
                    .Include(r => r.Match)
                    .Include(r => r.Section)
                    .ToListAsync();


            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            var section = await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == reservation.SectionId);
            section.OccupiedReservationSeats--;
            try
            {
                await _dbContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
