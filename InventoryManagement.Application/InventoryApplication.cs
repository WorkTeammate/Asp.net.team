using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.EfCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplicaton
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var opration = new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.MarketId==command.MarketId))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId,command.UnitPrice,command.MarketId);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult Edit(EditInventory command)
        {
            var opration = new OperationResult();
            var inventory = _inventoryRepository.Get(command.ProductId);
            if(inventory==null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id && x.MarketId==command.MarketId))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            inventory.Edit(command.ProductId,command.UnitPrice,command.MarketId);
            _inventoryRepository.SaveChanges();
            return opration.Successful();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var opration = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            inventory.Increase(command.Count, 0, command.Description);
            _inventoryRepository.SaveChanges();
             return opration.Successful();

        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var opration = new OperationResult();
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId,item.MarketId);
                inventory.Reduce(item.Count, 0, item.Description, item.OrderId);
            }
            _inventoryRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var opration = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            const long opratorId = 1;
            inventory.Reduce(command.Count, opratorId, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return opration.Successful();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
