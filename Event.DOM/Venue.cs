//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Event.DOM
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public partial class Venue
    {
        [Display(Name = "ID")]
        public int VenueID { get; set; }
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }
        public string VenueFilename { get; set; }
        public string VenueFilePath { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }

        [Display(Name = "Venue Price")]
        public Nullable<int> VenueCost { get; set; }
    }
}
