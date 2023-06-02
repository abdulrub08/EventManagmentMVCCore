using Event.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repository
{
    public interface IBookLightRepository
    {
        IEnumerable<Light> LightList(string LightType);
        int BookLight(BookingLight Light);
    }
}
