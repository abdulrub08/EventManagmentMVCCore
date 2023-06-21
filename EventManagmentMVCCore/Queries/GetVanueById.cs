using Event.DOM;
using MediatR;

namespace EventManagmentMVCCore.Queries
{
    public record GetVenueById(int Id) : IRequest<Venue>;
}
