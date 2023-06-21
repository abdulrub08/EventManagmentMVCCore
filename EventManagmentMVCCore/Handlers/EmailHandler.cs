using Event.DAL.Repository;
using EventManagmentMVCCore.Notification;
using MediatR;

namespace EventManagmentMVCCore.Handlers
{
    public class EmailHandler : INotificationHandler<VenueAddedNotification>
    {
        private readonly IVenueRepository _venueRepository;
        public EmailHandler(IVenueRepository venueRepository) => _venueRepository = venueRepository;
        public async Task Handle(VenueAddedNotification notification, CancellationToken cancellationToken)
        {
            await _venueRepository.EventOccured(notification.Venue, "Email sent");
            await Task.CompletedTask;
        }
    }
}
