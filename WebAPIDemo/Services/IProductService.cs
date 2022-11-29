﻿using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        int AddProduct(Product prod);

        int UpdateProduct(Product prod);

        int DeleteProduct(int id);
    }
}
