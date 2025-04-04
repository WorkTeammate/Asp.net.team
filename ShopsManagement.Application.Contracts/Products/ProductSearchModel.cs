﻿namespace ShopsManagement.Application.Contracts.Products
{
    public class ProductSearchModel
    {
        public long Id { get; set; }
        public string ShortDescription { get; set; }
        public long CategoryId { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
    }
}
