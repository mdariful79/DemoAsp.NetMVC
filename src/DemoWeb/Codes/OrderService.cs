namespace DemoWeb.Codes
{
    public class OrderService
    {
        private readonly INotificationService _notificationService;

        public OrderService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void PlaceOrder(string orderDetails)
        {
            // Logic to place the order
            Console.WriteLine("Order placed: " + orderDetails);

            // Send notification
            _notificationService.Send("Order placed: " + orderDetails);
        }
    }
}
