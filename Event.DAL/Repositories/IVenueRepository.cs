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
        void SaveVenue(Venue venue);
        void UpdateVenue(Venue venue);
        IEnumerable<Venue> ShowVenue();
        void DeleteVenue(int id);
        Venue VenueByID(int id);
    }
}
