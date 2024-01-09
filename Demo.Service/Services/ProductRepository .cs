using Demo.EntityFramework.Models;
using Demo.Model.QueryModel;
using Demo.Repository.Repositories;
using Demo.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Demo.Service.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _products;
        private readonly IRepository<Category> _categories;
        private readonly IRepository<User> _users;
        public ProductRepository(IRepository<Product> products, IRepository<Category> categories, IRepository<User> users)
        {
            _products = products ?? throw new ArgumentNullException(nameof(products));
            _categories = categories ?? throw new ArgumentNullException(nameof(categories));
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }
        public Task<Product> AddProductAsync(string productName, double price, double rating, int categoryId, IFormFile image)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductQ>> GetProductsAsync()
        {
            try
            {
                var allProducts = _products.GetAll();

                if (allProducts.Any())
                {
                    var products = await Task.Run(() =>
                            allProducts.Join(_categories.GetAll(),
                            product => product.CategoryId,
                            category => category.CategoryId,
                            (product, category) => new
                            {
                                product,
                                category.CategoryName
                            })
                            .Join(_users.GetAll().Where(x => x.IsActive),
                                product => product.product.VendorId,
                                user => user.UserId,
                                (product, user) => new ProductQ
                                {
                                    ProductId = product.product.ProductId,
                                    ProductName = product.product.ProductName,
                                    Price = product.product.Price,
                                    Rating = product.product.Rating,
                                    ImagePath = product.product.ImagePath,
                                    CategoryId = product.product.CategoryId,
                                    CategoryName = product.CategoryName,
                                    VendorId = product.product.VendorId,
                                    VendorName = user.UserName
                                })
                            .ToList());

                    return products;
                }

                return Enumerable.Empty<ProductQ>();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
