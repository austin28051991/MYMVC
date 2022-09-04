using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _dbContext;
        public ICategoryRespository Category { get;private set; }
        public IProductRespository Product { get; private set; }

        public UnitOfWork(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            Category = new CategoryRepository(dBContext);
            Product = new ProductRepository(dBContext);
        }


        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
