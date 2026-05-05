namespace DemoWeb.Codes
{
    public class UnitOfWork
    {
        public Repository<Product> Products { get; set; }

        public UnitOfWork()
        {
            Products = new Repository<Product>();
        }

        public void Save()
        {

        }
    }
}
