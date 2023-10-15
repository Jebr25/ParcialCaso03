using Microsoft.EntityFrameworkCore;
using ParcialCaso03.DOMAIN.Core.Entities;
using ParcialCaso03.DOMAIN.Core.Interfaces;
using ParcialCaso03.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialCaso03.DOMAIN.Infrastructure.Repositories
{
    public class TerritoryRepository : ITerritoryRepository
    {
        private readonly Dpa202302parcialCaso0320200136Context _dbContext;

        public TerritoryRepository(Dpa202302parcialCaso0320200136Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Territory>> GetAll()
        {
            return await _dbContext.Territory.ToListAsync();
        }

        public async Task<bool> Create(Territory territory)
        {
            await _dbContext.Territory.AddAsync(territory);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateById(Territory territory)
        {
            var existingTerritory = await _dbContext.Territory.FindAsync(territory.Id);

            if (existingTerritory == null)
            {
                return false;
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (territory.Description != null)
            {
                existingTerritory.Description = territory.Description;
            }

            if (territory.Area != null)
            {
                existingTerritory.Area = territory.Area;
            }

            if (territory.Population != null)
            {
                existingTerritory.Population = territory.Population;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteById(int id)
        {
            var territory = await _dbContext.Territory.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (territory == null)
                return false;

            _dbContext.Territory.Remove(territory);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }



    }
}
