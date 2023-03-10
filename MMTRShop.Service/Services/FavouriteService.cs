using AutoMapper;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using MMTRShop.Repository;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Service.Services
{
    public class FavouriteService: IFavouriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FavouriteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FavouriteDTO>> GetFavouritesByClientId(Guid clientId)
        {
            var favourites = await _unitOfWork.Favorites.GetFavourites(clientId);
            var result = _mapper.Map<IEnumerable<FavouriteDTO>>(favourites);
            return result;
        }
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites(FilterByClient filter)
        {
            var favourites = await _unitOfWork.Favorites.GetFavourites(filter);
            var result = _mapper.Map<IEnumerable<FavouriteDTO>>(favourites);
            return result;
        }
        public async Task<FavouriteDTO> GetFavourite(Guid favouriteId)
        {
            var favourite = await _unitOfWork.Favorites.GetByIdAsync(favouriteId);
            if (favourite == null)
            {
                throw new NotFoundException("Избраное не найдено");
            }
            var result = _mapper.Map<FavouriteDTO>(favourite);
            return result;
        }

        public async Task RemoveFavourite(Guid id)
        {
            var favourite = await _unitOfWork.Favorites.GetByIdAsync(id);
            if (favourite == null)
            {
                throw new NotFoundException("Избраное не найдено");
            }
            _unitOfWork.Favorites.Remove(id);
            await Save();
        }

        public async Task AddFavourite(FavouriteDTO favouriteDTO)
        {
            var favourites = await GetFavouritesByClientId(favouriteDTO.ClientId);
            foreach (var item in favourites)
            {
                if (item.ProductId== favouriteDTO.ProductId)
                {
                    throw new DublicateException("Товар уже находится в избраном");
                }
            }
            var favourite = _mapper.Map<Favourite>(favouriteDTO);
            _unitOfWork.Favorites.Add(favourite);
            await Save();
        }
        public async Task Update(FavouriteDTO favouriteDTO)
{
            var favourite = _mapper.Map<Favourite>(favouriteDTO);
            _unitOfWork.Favorites.Update(favourite);
            await Save();
        }
        public async Task Save()
        {
            await _unitOfWork.Favorites.SaveAsync();
        }
    }
}
