using Microsoft.AspNetCore.Http;

namespace IBT.Models
{
    public class EmailMessage
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
