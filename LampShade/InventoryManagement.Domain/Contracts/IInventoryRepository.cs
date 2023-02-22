using _0_Framework.Domain;
using InventoryManagement.Application.Contracts.Dtos.InventoryDtos;
using InventoryManagement.Domain.InventoryAggregate;

namespace InventoryManagement.Domain.Contracts
{
    public interface IInventoryRepository : IRepository<long , Inventory>
    {
        Inventory GetInventory(long id);
        EditInventory GetDetails(long id);
        List<InventoryDto> Search(SearchInventory search);
        List<InventoryOprationDto> GetInventoryOprations(long InventoryId);
    }
}
