using Dapper;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public class VenueRepository : BaseRepository, IVenueRepository
    {
        public VenueRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void DeleteVenue(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venue> ShowVenue()
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from Venue";
                IEnumerable<Venue> venues = connection.Query<Venue>(sql);
                return venues;
            }
        }

        public void UpdateVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public Venue VenueByID(int id)
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from Venue where VenueID="+ id;
                Venue venue = connection.QuerySingle<Venue>(sql);
                return venue;
            }
        }
    }
}
