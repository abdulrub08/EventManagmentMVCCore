using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.DOM;
namespace Event.DAL.Repository
{
    public interface IVenueRepository
    {
        Task<Venue> SaveVenueAsync(Venue venue);
        bool UpdateVenue(Venue venue);
        IEnumerable<Venue> ShowVenue();
        bool DeleteVenue(int id);
        Venue VenueByID(int id);
    }
}
