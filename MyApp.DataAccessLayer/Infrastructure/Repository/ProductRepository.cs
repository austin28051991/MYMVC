using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRespository
    {
        private readonly ApplicationDBContext _dbContext;
        public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product product)
        {
            var productdb = _dbContext.products.FirstOrDefault(x => x.Id == product.Id);
            if(productdb!= null)
            {
                productdb.Name=product.Name;
                productdb.Price=product.Price;
                productdb.Description=product.Description;
                if(product.ImageUrl!=null)
                {
                    productdb.ImageUrl=product.ImageUrl;
                }
                
            }
        }

        
    }
}
