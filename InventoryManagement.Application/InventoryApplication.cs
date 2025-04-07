using _01_Framework.Application;
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
        private readonly IAuthHelper _authHelper;

        public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
        {
            _inventoryRepository = inventoryRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateInventory command)
        {
            var opration = new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId,command.UnitPrice,command.AccountId);
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
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            inventory.Edit(command.ProductId,command.UnitPrice,command.AccountId);
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

            var account = _authHelper.CurrentAccountId();


            inventory.Increase(command.Count, account, command.Description);
            _inventoryRepository.SaveChanges();
             return opration.Successful();

        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var opration = new OperationResult();
            var account = _authHelper.CurrentAccountId();

            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, account, item.Description, item.OrderId);
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

            var account = _authHelper.CurrentAccountId();

            if (command.Count > inventory.CalculateCurrentCount())
                return opration.Failed("مقدار نمیتواند بیشتر از موجودی انبار باشد");

            inventory.Reduce(command.Count, account, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return opration.Successful();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
