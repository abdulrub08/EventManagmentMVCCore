using Event.DAL.Repository;
using EventManagmentMVCCore.Notification;
using MediatR;

namespace EventManagmentMVCCore.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<VenueAddedNotification>
    {
        private readonly IVenueRepository _venueRepository;

        public CacheInvalidationHandler(IVenueRepository venueRepository) => _venueRepository = venueRepository;

        public async Task Handle(VenueAddedNotification notification, CancellationToken cancellationToken)
        {
            await _venueRepository.EventOccured(notification.Venue, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
