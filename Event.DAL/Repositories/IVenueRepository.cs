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
        public Task<Venue> SaveVenueAsync(Venue venue);
        public bool UpdateVenue(Venue venue);
        public IEnumerable<Venue> ShowVenue();
        public Task<IEnumerable<Venue>> GetVenues();
        public bool DeleteVenue(int id);
        public Venue VenueByID(int id);
        public Task<Venue> VenueById(int id);
        public Task EventOccured(Venue venue, string evt);
    }
}
