using _0_Framework.Application;
using _0_Framework.Infrastructure;
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

        public InventoryRepository(InventoryContext context, ShopsContext shopsContext) : base(context)
        {
            _context = context;
            _ShopsContext = shopsContext;
        }

        public Inventory GetBy(long productId, long MarketId)
        {
            return _context.Inventory.FirstOrDefault(x=>x.ProductId == productId && x.MarketId==MarketId);
        }

        public EditInventory GetDetails(long id)
        {
           return _context.Inventory.Select(x=>new EditInventory
           {
               Id = x.Id,
               ProductId = x.ProductId,
               MarketId = x.MarketId,
               UnitPrice=x.UnitPrice,
           }).FirstOrDefault(x=>x.Id==id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
          var inventory = _context.Inventory.FirstOrDefault(x=>x.Id == inventoryId);
            var operation = inventory.Oprations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperatorId = 0,
                OprationDate=x.OprationDate.ToFarsi(),
                OrderID=x.OrderID,
                
            });

            return operation.OrderByDescending(x => x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _ShopsContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var Markets = _ShopsContext.Markets.Select(x => new { x.Id, x.PersianName }).ToList();
            var query = _context.Inventory.Select(x => new InventoryViewModel
            {
                Id= x.Id,
                CreationDate=x.CreationDate.ToFarsi(),
                CurrentCount=x.CalculateCurrentCount(),
                InStock=x.InStock,
                MarketId=x.MarketId,
                ProductId=x.ProductId,
                UnitPrice=x.UnitPrice,    
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.MarketId > 0)
                query = query.Where(x => x.MarketId == searchModel.MarketId);

            var inventory = query.OrderByDescending(x=>x.Id).ToList();
            inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                item.Markets = Markets.FirstOrDefault(x => x.Id == item.ProductId)?.PersianName;
            });

            return inventory;
        }
    }
}
