namespace EventManagmentMVCCore.ViewModel
{
    public class VenueViewModel
    {
        public string VenueName { get; set; }
        public string VenueFilename { get; set; }=string.Empty; 
        public string VenueFilePath { get; set; } = string.Empty;
        public Nullable<int> VenueCost { get; set; }
        public IFormFile Photo { get; set; }
    }
}
