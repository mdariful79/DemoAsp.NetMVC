using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Practice
{
    public class BulkEmailService : EmailService
    {
        private readonly EmailService _emailService;
        public BulkEmailService()
        {
            _emailService = new EmailService();
        }
        public void SendBulkEmail(List<string>recipientEmails, string subject, string message)
        {
            string formattingMessage = _emailService.FormatEmailBody("Valid customer", message);
        }
    }
}
