namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOpration
    {
        public long Id { get; private set; }
        /// <summary>
        /// به انبار وارد شده یا خارج شده
        /// </summary>
        public bool Operation { get; private set; }
        /// <summary>
        /// چه تعداد وارد و خارج شده
        /// </summary>
        public long Count { get; private set; }
        /// <summary>
        /// چه شخصی اینکارو کرده
        /// </summary>
        public long OperatorId { get; private set; }
        /// <summary>
        /// تاریخ ورود و خروج
        /// </summary>
        public DateTime OprationDate { get; private set; }
        /// <summary>
        /// در تاریخی که این عملیات انجام شده موجودی انبار چقدر بوده است
        /// </summary>
        public long CurrentCount { get; private set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// اگر بر اساس سفارش مشتری بوده است شماره سفارش رو بزند
        /// </summary>
        public long OrderID { get; private set; }
        /// <summary>
        /// این عملیات مربوط به کدام انبار بوده
        /// </summary>
        public long InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        protected InventoryOpration()
        {

        }
        public InventoryOpration(bool operation, long count, long operatorId, long currentCount,
            string description, long orderID, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderID = orderID;
            InventoryId = inventoryId;
            OprationDate = DateTime.Now;
        }
    }
}
