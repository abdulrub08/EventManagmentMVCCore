namespace EventManagmentMVCCore.Services
{
    public class FileUploadServices: IFileUploadServices
    {
        private readonly IWebHostEnvironment hostingEnvironment;
       public FileUploadServices(IWebHostEnvironment hostingEnvironment) {
        this.hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> Upload(IFormFile file)
        {   
            // The image must be uploaded to the images folder in wwwroot
            // To get the path of the wwwroot folder we are using the inject
            // HostingEnvironment service provided by ASP.NET Core
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles");

            // To make sure the file name is unique we are appending a new
            // GUID value and and an underscore to the file name
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Use CopyTo() method provided by IFormFile interface to
            // copy the file to wwwroot/images folder
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        } 
    }
    public interface IFileUploadServices
    {
        Task<string> Upload(IFormFile file);
    }
}
