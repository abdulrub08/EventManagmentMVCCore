using Event.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.DAL.Repository
{
    public interface IFlowerRepository
    {
        void SaveFlower(Flower Flower);
        void UpdateFlower(Flower Flower);
        IEnumerable<Flower> ShowFlower();
        void DeleteFlower(int id);
        Flower FlowerByID(int id);
        
    }
}