using System.Net.Mail;

namespace EventManagmentMVCCore.Services
{
    public class SmtpServices : ISmtpServices
    {
        private readonly SmtpClient smtpClient;
        private IConfiguration ConfigRoot;
        private readonly ILogger<SmtpServices> _logger;
        private readonly List<EmailTemplate> emailTemplates;
        public SmtpServices(IConfiguration configRoot,
            ILogger<SmtpServices> logger)
        {
            ConfigRoot = (IConfiguration)configRoot;
            _logger = logger;
            emailTemplates = new List<EmailTemplate>();
            AddTemplates();
            smtpClient = new SmtpClient
            {
                Host = ConfigRoot.GetSection("EmailConfig:Host").Value,
                Port = Convert.ToInt32(ConfigRoot.GetSection("EmailConfig:Port").Value),
                EnableSsl = Convert.ToBoolean(ConfigRoot.GetSection("EmailConfig:EnableSsl").Value),
                UseDefaultCredentials = false
            };
        }
        public void SendEmailAsync(string email, string type, string[] args)
        {
            EmailTemplate emailTemplate = new EmailTemplate();
            emailTemplate = GetEmailTemplateByType(type);

            StreamReader str = new StreamReader(emailTemplate.FilePath);
            string _mailbody = str.ReadToEnd();
            str.Close();
            emailTemplate.Body = string.Format(_mailbody, args);
            //var mailMessage = new MailMessage("noreply@laureate.net.au""Myreply@localhost.com",email)
            string toAddresses = ConfigRoot.GetSection("EmailConfig:IsTest").Value == "Yes" ? ConfigRoot.GetSection("EmailConfig:ToAddress").Value : email;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigRoot.GetSection("EmailConfig:FromAddress").Value, "Torrens University Australia & Think Education");
            foreach (var address in toAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(address);
            }
            mailMessage.Subject = emailTemplate.Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = emailTemplate.Body;
            smtpClient.Send(mailMessage);
            //mailSetup.SendEmail(emailTemplate);
        }
        public EmailTemplate GetEmailTemplateByType(string _type)
        {
            return emailTemplates.FirstOrDefault(x => x.Type == _type);
        }
        private void AddTemplates()
        {
            #region With SSO
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Torrens University: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOElectronic.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOElectronic"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Think Education: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOElectronicThink.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOElectronicThink"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Torrens University: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOElectronicHard.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOElectronicHard"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Think Education: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOElectronicHardThink.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOElectronicHardThink"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Torrens University: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOHard.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOHard"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Think Education: Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/SSO/SSOHardThink.html",
                IsHtml = true,
                SSL = true,
                Type = "SSOHardThink"
            });
            #endregion
            #region NON SSO
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/NoSSO/AlumniAllElectronic.html",
                IsHtml = true,
                SSL = true,
                Type = "AlumniAllElectronic"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/NoSSO/AlumniElectronicHard.html",
                IsHtml = true,
                SSL = true,
                Type = "AlumniElectronicHard"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Subject = "Document Request Ref# (include enquiry reference number)",
                FilePath = "EmailTemplates/NoSSO/AlumniAllHard.html",
                IsHtml = true,
                SSL = true,
                Type = "AlumniAllHard"
            });
            #endregion
        }
        public string GetStudentTypeKey(string _key)
        {
            string _htmlTemplate = string.Empty;
            switch (_key)
            {
                case "SSOE":
                    _htmlTemplate = "SSOElectronic";
                    break;
                case "SSOET":
                    _htmlTemplate = "SSOElectronicThink";
                    break;
                case "SSOEH":
                    _htmlTemplate = "SSOElectronicHard";
                    break;
                case "SSOEHT":
                    _htmlTemplate = "SSOElectronicHardThink";
                    break;
                case "SSOH":
                    _htmlTemplate = "SSOHard";
                    break;
                case "SSOHT":
                    _htmlTemplate = "SSOHardThink";
                    break;
                case "AE":
                    _htmlTemplate = "AlumniAllElectronic";
                    break;
                case "AEH":
                    _htmlTemplate = "AlumniElectronicHard";
                    break;
                case "AH":
                    _htmlTemplate = "AlumniAllHard";
                    break;
            }
            return _htmlTemplate;
        }
    }
}
