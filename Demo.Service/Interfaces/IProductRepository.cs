using Demo.EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Demo.Model.QueryModel;

namespace Demo.Service.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(string productName, double price, double rating, int categoryId, IFormFile image);
        Task<IEnumerable<ProductQ>> GetProductsAsync();
    }
}
