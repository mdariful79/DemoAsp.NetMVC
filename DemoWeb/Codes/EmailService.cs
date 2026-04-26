namespace DemoWeb.Codes
{
    public class EmailService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);

        }
    }
}
