using Event.DOM;
using MediatR;

namespace EventManagmentMVCCore.Notification
{
    public record VenueAddedNotification(Venue Venue) : INotification;
}
