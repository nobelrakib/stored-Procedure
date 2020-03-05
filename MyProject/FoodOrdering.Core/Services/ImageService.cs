using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Services
{
    public class ImageService : IImageService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public ImageService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddImage(FoodImage foodimage)
        {
            if (foodimage == null || string.IsNullOrWhiteSpace(foodimage.Url))
                throw new InvalidOperationException("FoodItem name is missing");

            _storeUnitOfWork.ImageRepository.Add(foodimage);
            _storeUnitOfWork.Save();
        }
        public FoodImage GetFoodImage(int id)
        {
            return _storeUnitOfWork.ImageRepository.GetById(id);
        }
    }
}
