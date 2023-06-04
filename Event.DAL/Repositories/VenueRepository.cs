using Dapper;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public class VenueRepository : BaseRepository, IVenueRepository
    {
        public VenueRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool DeleteVenue(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Venue> SaveVenueAsync(Venue venue)
        {
            var query = "INSERT INTO Venue (VenueName, VenueCost, VenueFilename,VenueFilePath,Createdby,Createdate) VALUES (@VenueName, @VenueCost, @VenueFilename,@VenueFilePath,@Createdby,@Createdate)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("@VenueFilename", venue.VenueFilename);
            parameters.Add("@VenueName", venue.VenueName);
            parameters.Add("@VenueCost", venue.VenueCost);
            parameters.Add("@VenueFilePath", venue.VenueFilePath);
            parameters.Add("@Createdby", venue.Createdby);
            parameters.Add("@Createdate", DateTime.Now);
            using (var connection = CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdVenue = new Venue
                {
                    VenueID = id,
                    VenueName = venue.VenueName
                };
                return createdVenue;
            }
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

        public bool UpdateVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public Venue VenueByID(int id)
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from Venue where VenueID= @Id";
                Venue venue = connection.QuerySingle<Venue>(sql,new { id });
                return venue;
            }
        }
    }
}
