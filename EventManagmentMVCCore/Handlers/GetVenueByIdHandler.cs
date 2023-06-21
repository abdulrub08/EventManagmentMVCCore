using Event.DAL.Repository;
using Event.DOM;
using EventManagmentMVCCore.Queries;
using MediatR;

namespace EventManagmentMVCCore.Handlers
{
    public class GetVenueByIdHandler : IRequestHandler<GetVenueById, Venue>
    {
        private readonly IVenueRepository _venueRepository;
        public GetVenueByIdHandler(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }
        public async Task<Venue> Handle(GetVenueById request, CancellationToken cancellationToken) =>
            await _venueRepository.VenueById(request.Id);
        //public async Task<Venue> Handle(GetVenueById request, CancellationToken cancellationToken)
        //{
        //   return await _venueRepository.VenueById(request.Id);
        //}
    }
}
