using ParcialCaso03.DOMAIN.Core.Entities;

namespace ParcialCaso03.DOMAIN.Core.Interfaces
{
    public interface ITerritoryRepository
    {
        Task<IEnumerable<Territory>> GetAll();
        Task<bool> Create(Territory territory);
        Task<bool> UpdateById(Territory territory);
        Task<bool> DeleteById(int id);

    }
}