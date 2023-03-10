using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.Commands;
using MMTRShop.Repository.Repositories;

namespace MMTRShopWPF.ViewModels
{
    public class InfoProductViewModel: BaseViewModel
    {
        private int countShow = 4;
        private CartService CartService = new CartService(new UnitOfWork(new ShopContext()));
        private FavouritesService FavouritesService = new FavouritesService(new UnitOfWork(new ShopContext()));
        public InfoProductViewModel(Product product)
        {
            if (product != null)
            {
                Product = product;
            }
            if (Product.CountInStarage < countShow)
            {
                if (Product.CountInStarage == 0)
                {
                    StatusProduct = "Закончился";
                    VisibilityCount = Visibility.Collapsed;
                }
                else
                {
                    StatusProduct = "Доступен";
                    VisibilityCount = Visibility.Visible;
                }
            }
            else
            {
                StatusProduct = "Доступен";
                VisibilityCount = Visibility.Collapsed;
            }
            if (AccountManager.Client == null)
            {
                isLikePath = "/Resources/NoLike.png";
            }
            else
            {
                favourit = FavouritesService.GetFavourit(product);
                if (favourit == null)
                {
                    isLikePath = "/Resources/NoLike.png";
                }
                else
                {
                    isLikePath = "/Resources/Like.png";
                }
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
                OnPropertyChanged(nameof(Product));
            }
        }
        protected string statusProduct;
        public string StatusProduct
        {
            get { return statusProduct; }
            set
            {
                statusProduct = value;
                OnPropertyChanged(nameof(StatusProduct));
            }
        }
        private Favourites favourit = new Favourites();
        public Favourites Favourit
        {
            get { return favourit; }
            set
            {
                favourit = value;
                OnPropertyChanged(nameof(Favourit));
            }
        }
        private ICommand addInCart;
        public ICommand AddInCart
        {
            get
            {
                if (addInCart == null) addInCart = new AddInCartCommand(this);
                return addInCart;
            }
        }
        protected string isLikePath;
        public string IsLikePath
        {
            get { return isLikePath; }
            set
            {
                isLikePath = value;
                OnPropertyChanged(nameof(IsLikePath));
            }
        }

        private ICommand clickLike;
        public ICommand ClickLike
        {
            get
            {
                if (clickLike == null) clickLike = new ClickLikeCommand(this);
                return clickLike;
            }
        }
        protected Visibility visibilityCount;
        public Visibility VisibilityCount
        {
            get
            {
                return visibilityCount;
            }
            set
            {
                visibilityCount = value;
                OnPropertyChanged(nameof(VisibilityCount));
            }
        }
    }
}
