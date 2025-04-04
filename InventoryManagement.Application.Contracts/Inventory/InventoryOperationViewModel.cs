namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryOperationViewModel
    {
        public long Id { get; set; }
        /// <summary>
        /// به انبار وارد شده یا خارج شده
        /// </summary>
        public bool Operation { get; set; }
        /// <summary>
        /// چه تعداد وارد و خارج شده
        /// </summary>
        public long Count { get; set; }
        /// <summary>
        /// چه شخصی اینکارو کرده
        /// </summary>
        public long OperatorId { get; set; }
        public string Operator { get; set; }
        /// <summary>
        /// تاریخ ورود و خروج
        /// </summary>
        public string OprationDate { get; set; }
        /// <summary>
        /// در تاریخی که این عملیات انجام شده موجودی انبار چقدر بوده است
        /// </summary>
        public long CurrentCount { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// اگر بر اساس سفارش مشتری بوده است شماره سفارش رو بزند
        /// </summary>
        public long OrderID { get; set; }
    }
}
