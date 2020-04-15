using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketVerkoop.Domain.Context;
using TicketVerkoop.Repository.Interfaces;

namespace TicketVerkoop.Repository
{
    public class SectionDAO: ISectionDAO
    {
        private readonly TicketVerkoopDbContext _dbContext;

        public SectionDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task<Section> FindById(string sectionId)
        {
            try
            {
                return await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == sectionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Sections.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Section>> GetAllByStadiumAsync(string stadiumId)
        {
            try
            {
                return await _dbContext.Sections
                    .Where(s => s.StadiumId == stadiumId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
