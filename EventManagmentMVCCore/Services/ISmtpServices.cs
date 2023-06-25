namespace EventManagmentMVCCore.Services
{
    public interface ISmtpServices
    {
        void SendEmailAsync(string email, string type, string[] args);
        EmailTemplate GetEmailTemplateByType(string _type);
        string GetStudentTypeKey(string _key);
    }
}
