using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MMTRShopWPF.Commands
{
    public class RemoveFavouritCommand:BaseCommand<FavouritesViewModel>
    {
        private FavouritesService FavouritesService = new FavouritesService(new UnitOfWork(new ShopContext()));
        public RemoveFavouritCommand(FavouritesViewModel favouritesViewModel) : base(favouritesViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Guid id = Guid.Parse(parameter.ToString());
            FavouritesService.RemoveFavouritById(id);
            viewModel.Favorites = FavouritesService.GetFavourites();
        }
    }
}
