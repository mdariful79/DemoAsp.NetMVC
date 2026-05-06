namespace DemoWeb.Codes
{
    public class Repository<T>
    {
        public void Add(T product)
        {

        }
        public void Update(T product)
        {

        }
        public void Delete(T product)
        {

        }
        public void Get(int id)
        {
            throw new NotImplementedException();
        }

    }
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetBestSellingProducts(int count)
        {
            throw new NotImplementedException();
            //return c.Products.Where(p => p.TotalSales > 1000 && p.Stock>100);
        }
        public void AddPopularProducts(ProductRepository repository)
        {
            var popularProducts = repository.GetBestSellingProducts(10);
            foreach (var product in popularProducts)
            {
                repository.Add(product);
            }
        }
    }
}
