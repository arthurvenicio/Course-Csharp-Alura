using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace ApiUsers.Models
{
    public class Message
    {
        public List<MailboxAddress> Destination { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        
        public Message(IEnumerable<string> destination, string subject, int userId, string code)
        {
            Destination = new List<MailboxAddress>();
            Destination.AddRange(destination.Select(d => new MailboxAddress(d)));
            Subject = subject;
            Content = $"https://localhost:5001/api/user/confirmation?accountId={userId}&code={code}";
        }
    }
}