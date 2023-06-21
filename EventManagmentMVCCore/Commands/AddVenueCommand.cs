using Event.DOM;
using MediatR;

namespace EventManagmentMVCCore.Commands
{
    public record AddVenueCommand(Venue venue) : IRequest<Venue>;
}
