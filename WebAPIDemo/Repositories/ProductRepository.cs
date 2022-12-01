using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddProduct(Product prod)
        {
            _context.products.Add(prod);
            var res = _context.SaveChanges();
            return res;
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            var prod=_context.products.Find(id);
            if (prod != null)
            {
                _context.products.Remove(prod);
                res=_context.SaveChanges();
            }
            return res;

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.products.ToList();
        }

        public Product GetProductById(int id)
        {
            var prod = _context.products.Find(id);
            return prod;

        }

        public int UpdateProduct(Product prod)
        {

            int res = 0;
            var p = _context.products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = prod.Name;
                p.Company_Name = prod.Company_Name;
                p.Price = prod.Price;
               
                res = _context.SaveChanges();
            }
            return res;

        }
    }
}
