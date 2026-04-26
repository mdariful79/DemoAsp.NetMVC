namespace DemoWeb.Codes
{
    public class SmsService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }
}
