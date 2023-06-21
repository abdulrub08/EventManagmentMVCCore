using Event.DAL.Repository;
using Event.DOM;
using EventManagmentMVCCore.Queries;
using MediatR;

namespace EventManagmentMVCCore.Handlers
{
    public class GetVenueHandler : IRequestHandler<GetVenue, IEnumerable<Venue>>
    {
        private readonly IVenueRepository _venueRepository;
        public GetVenueHandler(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }
        public async Task<IEnumerable<Venue>> Handle(GetVenue request, CancellationToken cancellationToken) => await _venueRepository.GetVenues();
        //public async Task<IEnumerable<Venue>> Handle(GetVenue request, CancellationToken cancellationToken)
        //{
        //   return await _venueRepository.GetVenues();
        //}
    }
}
