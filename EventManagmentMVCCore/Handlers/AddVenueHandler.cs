using Event.DAL.Repository;
using Event.DOM;
using EventManagmentMVCCore.Commands;
using MediatR;

namespace EventManagmentMVCCore.Handlers
{
    public class AddVenueHandler : IRequestHandler<AddVenueCommand, Venue>
    {
        private readonly IVenueRepository _venueRepository;

        public AddVenueHandler(IVenueRepository venueRepository) => _venueRepository = venueRepository;

        public async Task<Venue> Handle(AddVenueCommand request, CancellationToken cancellationToken)
        {
            var venue = await _venueRepository.SaveVenueAsync(request.venue);

            return venue;
        }
    }
}
