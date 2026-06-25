using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Practice
{
    public class EmailService
    {
        public string FormatEmailBody(string recipientName, string message)
        {
            return $"Dear {recipientName},\n\n{message}\n\nBest regards,\nYour Company";
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            string formattedBody = FormatEmailBody(recipientEmail, body);

            // Simulate sending an email
            Console.WriteLine($"Sending email to: {recipientEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body:\n{body}");
        }
    }
}
