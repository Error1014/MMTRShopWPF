﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.Commands;

namespace MMTRShopWPF.ViewModels
{
    public class EditProductViewModel: BaseViewModel
    {
        private CategoryService CategoryService = new CategoryService();
        protected BrandService BrandService = new BrandService();
        private ProductService ProductService = new ProductService();
        public EditProductViewModel(Product product)
        {
            AllCategory = CategoryService.GetAllCategory();
            AllBrand = BrandService.GetAllBrand();
            if (AccountManager.Admin == null)
            {
                isAdmin = false;
                BlockOpacity = 0.3f;
            }
            else
            {
                isAdmin = true;
                BlockOpacity = 1;
            }
            if (product == null)
            {
                isAdd = true;
                Product = new Product();
            }
            else
            {
                isAdd = false;
                Product = ProductService.GetProduct(product);
            }
        }
        private Product product = new Product();

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                SelectCategory = CategoryService.GetCategory(value)==null? AllCategory[0] : CategoryService.GetCategory(value);
                SelectBrand = BrandService.GetBrand(value)==null? AllBrand[0] : BrandService.GetBrand(value);
                OnPropertyChanged(nameof(Product));
            }
        }

        private bool isAdd;
        public bool IsAdd
        {
            get { return isAdd; }
            set
            {
                isAdd = value;
                OnPropertyChanged(nameof(IsAdd));
            }
        }
        public List<Category> AllCategory { get; private set; }
        private Category selectCategory;
        public Category SelectCategory
        {
            get { return selectCategory; }
            set
            {
                selectCategory = value;
                if (value!=null)
                {
                    Product.CategoryId = value.Id;
                }
                OnPropertyChanged(nameof(SelectCategory));
            }
        }
        
        public List<Brand> AllBrand { get; private set; }
        protected Brand selectBrand;
        public Brand SelectBrand
        {
            get { return selectBrand; }
            set
            {
                selectBrand = value;
                if (value != null)
                {
                    Product.BrandId = value.Id;
                }
                OnPropertyChanged(nameof(SelectBrand));
            }
        }
        private ICommand saveResult;

        public ICommand SaveResult
        {
            get
            {
                if (saveResult == null) saveResult = new EditProductSaveResultCommand(this);
                return saveResult;
            }
        }
        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null) delete = new EditProductRemoveCommand(this);
                return delete;
            }
        }
        protected bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        private float blockOpacity;
        public float BlockOpacity
        {
            get { return blockOpacity; }
            set
            {
                blockOpacity = value;
                OnPropertyChanged(nameof(BlockOpacity));
            }
        }
    }
}
