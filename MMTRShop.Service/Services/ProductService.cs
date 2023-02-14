﻿using MMTRShop.MiddlewareException;
using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;
using System.Collections.ObjectModel;

namespace MMTRShop.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var result = await _unitOfWork.Products.GetByIdAsync(id);
            if (result == null)
            {
                throw new NotFoundException("Товар не найден");
            }
            return result;
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            Save();
        }
        public async Task RemoveProduct(Product product)
        {
            Product? productDB = await GetProduct(product.Id);
            _unitOfWork.Products.Remove(productDB);
            Save();
        }
        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            Save();
        }
        public void Save()
        {
            _unitOfWork.Products.Save();
        }
        public void CreateOrUpdateProduct(bool isAdd, Product product)
        {
            if (isAdd)
            {
                AddProduct(product);
            }
            Save();
        }
        public void RemoveOrUpdateProduct(bool isAdd, Product product)
        {
            if (!isAdd)
            {
                RemoveProduct(product);
            }
            Save();
        }
        public async Task<List<Product>> GetProductsByCart(List<Cart> carts)
        {
            var products = carts.Join(await _unitOfWork.Products.GetAllAsync(),
            k => k.ProductId,
            p => p.Id, (k, p) => new { k, p }).Select(x => x.p).ToList();
            return products;
        }
        public async Task<List<Product>> GetProductsByFavourite(List<Favourite> favourites)
        {
            var products = favourites.Join(await _unitOfWork.Products.GetAllAsync(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }

        public async Task<ObservableCollection<Product>> GetPageProducts(ProductPageFilter filter)
        {
            var products = await _unitOfWork.Products.GetProductsPage(filter);
            return new ObservableCollection<Product>(products);
        }
        public int GetCountPage(int sizePage)
        {
            return _unitOfWork.Carts.GetCountPage(sizePage);
        }

        public async void RemoveProductsInStorage(List<Cart> carts)
        {
            foreach (var item in carts)
            {
                var product = await _unitOfWork.Products.FindAsync(p => p.Id == item.ProductId);
                product.CountInStarage -= item.ProductCount;
            }
            Save();
        }

    }
}
