using Microsoft.AspNetCore.Http;

namespace ShopsManagement.Application.Contracts.Products
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }
    }
}
