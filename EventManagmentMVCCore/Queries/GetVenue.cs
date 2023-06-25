using Event.DOM;
using MediatR;

namespace EventManagmentMVCCore.Queries
{
    public class GetVenue : IRequest<IEnumerable<Venue>>
    {

    }
}
