using _0_Framework.Domain;
using ShopsManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOpration> Oprations { get; private set; }
        protected Inventory() { }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;

        }
        /// <summary>
        /// در حال حاضر چه تعدادی در انبار وجود دارد
        /// </summary>
        /// <returns></returns>
        public long CalculateCurrentCount()
        {
            var plus = Oprations.Where(x => x.Operation).Sum(x => x.Count);
            var Minus = Oprations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - Minus;
        }
        /// <summary>
        /// افزایش موجودی
        /// </summary>
        /// <param name="count">تعداد افزایش</param>
        /// <param name="OperatorId">چه کسی این کار را انجام میدهد </param>
        /// <param name="description">توضیحات</param>
        public void Increase(long count, long OperatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var opration = new InventoryOpration(true, count, OperatorId, currentCount, description, 0, Id);
            Oprations.Add(opration);
            InStock = currentCount > 0;
        }
        /// <summary>
        /// کاهش موجودی
        /// </summary>
        /// <param name="count">تعداد کاهش</param>
        /// <param name="OperatorId">چه کسی این کار را انجام میدهد</param>
        /// <param name="description">توضیحات</param>
        /// <param name="orderId">شماره سفارش مشتری</param>
        public void Reduce(long count, long OperatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var opration = new InventoryOpration(false, count, OperatorId, currentCount, description, orderId, Id);
            Oprations.Add(opration);
            if (currentCount < 0)
            {
                InStock = false;
            }


        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }


    }
}
