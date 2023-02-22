using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Dtos.InventoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Contracts
{
    public interface IInventoryApplication
    {
        OprationResult Create(CreateInventory command);
        OprationResult Edit(EditInventory command);
        OprationResult Increase(IncreaseInventory command);
        OprationResult ReduceInventory(ReduceInventory command);
        OprationResult ReduceInventory(List<ReduceInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryDto> Search(SearchInventory search);
        List<InventoryOprationDto> GetInventoryOprations(long InventoryId);
    }
}
