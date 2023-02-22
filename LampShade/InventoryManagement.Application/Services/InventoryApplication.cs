using InventoryManagement.Application.Contracts.Contracts;
using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Dtos.InventoryDtos;
using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.InventoryAggregate;

namespace InventoryManagement.Application.Services
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OprationResult Create(CreateInventory command)
        {
            var opration = new OprationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult Edit(EditInventory command)
        {
            var opration = new OprationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if(inventory == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if(_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.ID != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditInventory GetDetails(long id) => _inventoryRepository.GetDetails(id);

        public List<InventoryOprationDto> GetInventoryOprations(long InventoryId) =>
            _inventoryRepository.GetInventoryOprations(InventoryId);

        public OprationResult Increase(IncreaseInventory command)
        {
            var opration = new OprationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            const long opratorId = 1;
            inventory.Increase(command.Count,opratorId,command.Description);
            _inventoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult ReduceInventory(ReduceInventory command)
        {
            var opration = new OprationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            const long opratorId = 1;
            inventory.Reduce(command.Count, opratorId, command.Description,0);
            _inventoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult ReduceInventory(List<ReduceInventory> command)
        {
            var opration = new OprationResult();
            const long opratorId = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetInventory(item.ProductId);
                inventory.Reduce(item.Count, opratorId, item.Description, item.OrderId);
            }
            _inventoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public List<InventoryDto> Search(SearchInventory search) =>
            _inventoryRepository.Search(search);
    }
}
