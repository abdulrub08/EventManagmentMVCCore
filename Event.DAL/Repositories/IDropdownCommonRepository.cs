using Event.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repository
{
    public interface IDropdownCommonRepository
    {
        IEnumerable<Country> GetCountry();
        IEnumerable<State> GetStatebyID(int ID);
        IEnumerable<City> GetCitybyID(int ID);
    }
}
