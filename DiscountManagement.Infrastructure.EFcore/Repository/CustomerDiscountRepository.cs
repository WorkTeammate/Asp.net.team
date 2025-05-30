﻿using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFcore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long,CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopsContext _shopsContext;
        private readonly AccountContext _accountContext;


        public CustomerDiscountRepository(DiscountContext discountContext
            , ShopsContext shopsContext, AccountContext accountContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopsContext = shopsContext;
            _accountContext = accountContext;
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return _discountContext.CustomerDiscount.Select(x => new EditCustomerDiscount
            {
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(CultureInfo.InvariantCulture),
                EndDate = x.EndDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                ProductId = x.ProductId,
                Reason = x.Reason,

            }).FirstOrDefault(x=>x.Id==Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var Accounts = _accountContext.Account.Select(x => new { x.Id, x.Username }).ToList();
            var product = _shopsContext.Products.Select(x=>new {x.Id,x.Name }).ToList();
            var query = _discountContext.CustomerDiscount.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate= x.DiscountRate,
                EndDate= x.EndDate.ToFarsi(),
                EndDateGr= x.EndDate,
                StartDate=x.StartDate.ToFarsi(),
                StartDateGr= x.StartDate,
                ProductId=x.ProductId,
                AccountId=x.AccountId,
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateGr >= searchModel.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query = query.Where(x => x.EndDateGr <= searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount => 
            {
                discount.Product = product.FirstOrDefault(x => x.Id == discount.ProductId)?.Name;
                discount.Accounts = Accounts.FirstOrDefault(x => x.Id == discount.ProductId)?.Username;
            });
            return discounts;

        }
    }
}
