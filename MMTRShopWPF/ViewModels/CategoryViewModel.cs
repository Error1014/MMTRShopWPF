﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Commands
{
    public class CategoryViewModel:BaseViewModel
    {
        private CategoryService CategoryService = new CategoryService();
        public CategoryViewModel()
        {
            Categories = CategoryService.GetCategories();
            if (AccountManager.Admin == null)
            {
                VisibilityBtnAdminRemoveAdd = false;
            }
            else
            {
                visibilityBtnAdminRemoveAdd = true;
            }
        }

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }


        private Category category = new Category();
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private ICommand add;
        public ICommand AddCategory
        {
            get
            {
                if (add == null) add = new AddCategoryCommand(this);
                return add;
            }
        }
        private ICommand remove;
        public ICommand RemoveCategory
        {
            get
            {
                if (remove == null) remove = new RemoveCategoryCommand(this);
                return remove;
            }
        }
        private ICommand save;
        public ICommand SaveChanged
        {
            get
            {
                if (save == null) save = new SaveCategoryCommand(this);
                return save;
            }
        }

        private bool visibilityBtnAdminRemoveAdd;
        public bool VisibilityBtnAdminRemoveAdd
        {
            get { return visibilityBtnAdminRemoveAdd; }
            set
            {
                visibilityBtnAdminRemoveAdd = value;
                OnPropertyChanged(nameof(VisibilityBtnAdminRemoveAdd));
            }
        }
    }
}
