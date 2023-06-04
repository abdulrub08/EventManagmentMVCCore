using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DOM
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile postedFiles { get; set; }
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FileNames { get; set; }
    }
}
