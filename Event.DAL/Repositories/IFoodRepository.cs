using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.DOM;
namespace Event.DAL.Repository
{
    interface IFoodRepository
    {
        void SaveFood(Food Food);
        IEnumerable<Food> ShowFood();
        void DeleteFood(int id);
        Food FoodByID(int id);
        void UpdateFood(Food Food);
        
    }
}
