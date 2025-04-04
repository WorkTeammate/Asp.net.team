using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopsContext _ShopsContext;
        private readonly AccountContext _accountContext;

        public InventoryRepository(InventoryContext context
            , ShopsContext shopsContext, AccountContext accountContext) : base(context)
        {
            _context = context;
            _ShopsContext = shopsContext;
            _accountContext = accountContext;
        }

        public Inventory GetBy(long productId)
        {
            return _context.Inventory.FirstOrDefault(x=>x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
           return _context.Inventory.Select(x=>new EditInventory
           {
               Id = x.Id,
               ProductId = x.ProductId,
               UnitPrice=x.UnitPrice,
           }).FirstOrDefault(x=>x.Id==id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var account = _accountContext.Account.Select(x => new { x.Id, x.Username }).ToList();
            var inventory = _context.Inventory.FirstOrDefault(x=>x.Id == inventoryId);
            var operation = inventory.Oprations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OprationDate = x.OprationDate.ToFarsi(),
                OperatorId = x.OperatorId,
                OrderID = x.OrderID,
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var opration in operation)
            {
                opration.Operator = account.FirstOrDefault(x => x.Id == opration.OperatorId)?.Username;
            }
            return operation;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _ShopsContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var Accounts = _accountContext.Account.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Inventory.Select(x => new InventoryViewModel
            {
                Id= x.Id,
                CreationDate=x.CreationDate.ToFarsi(),
                CurrentCount=x.CalculateCurrentCount(),
                InStock=x.InStock,
                ProductId=x.ProductId,
                UnitPrice=x.UnitPrice,  
                AccountId=x.AccountId,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.AccountId > 0)
                query = query.Where(x => x.AccountId == searchModel.AccountId);

            var inventory = query.OrderByDescending(x=>x.Id).ToList();
            inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                item.Accounts = Accounts.FirstOrDefault(x => x.Id == item.ProductId)?.Username;
            });

            return inventory;
        }
    }
}
