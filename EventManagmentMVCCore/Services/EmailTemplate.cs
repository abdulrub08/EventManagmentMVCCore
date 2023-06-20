namespace EventManagmentMVCCore.Services
{
    public class EmailTemplate
    {
        public string FilePath { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public bool SSL { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Blind_copy_recipients { get; set; }
    }
}