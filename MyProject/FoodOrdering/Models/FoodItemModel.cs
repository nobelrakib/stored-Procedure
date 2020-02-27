using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
namespace FoodOrdering.Models
{
    public class FoodItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        private IFoodItemService _fooditemService;
        public FoodItemModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public FoodItemModel(IFoodItemService fooditemService)
        {
            _fooditemService = fooditemService;
        }
        public IEnumerable<FoodItemModel> ListofFoodItemModel()
        {
            var listoffooditem = _fooditemService.GetFoodItemList();
            var fooditemmodellist = new List<FoodItemModel>();
            foreach(var item in listoffooditem)
            {
                var singlefooditemmodel = new FoodItemModel();
                singlefooditemmodel.Name = item.Name;
                singlefooditemmodel.Price = item.Price;
                singlefooditemmodel.Description = item.Description;
                singlefooditemmodel.Id = item.Id;
                fooditemmodellist.Add(singlefooditemmodel);
            }
            return fooditemmodellist;
        }
    }
}
