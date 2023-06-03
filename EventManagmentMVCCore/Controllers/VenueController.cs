using Event.DAL.Repository;
using Event.DOM;
using Microsoft.AspNetCore.Mvc;

namespace EventManagmentMVCCore.Controllers
{
    public class VenueController : Controller
    {
        private readonly ILogger<VenueController> _logger;
        private readonly IVenueRepository _venueRepository;
        public VenueController(ILogger<VenueController> logger, IVenueRepository venueRepository)
        {
            _logger = logger;
            _venueRepository = venueRepository;
        }
        public IActionResult VenueShowall()
        {
            IEnumerable<Venue> venues = _venueRepository.ShowVenue();
            return View(venues);
        }
        public IActionResult VenueEdit(int id)
        {
            Venue venue = _venueRepository.VenueByID(id);
            return View(venue);
        }
        [HttpPost]
        public IActionResult VenueEdit(Venue venue)
        {
            if (ModelState.IsValid)
            {
               
                return View();
            }
            return View(venue);
        }
        public IActionResult VenueDetails(int id)
        {
            Venue venue = _venueRepository.VenueByID(id);
            return View(venue);
        }
    }
}
