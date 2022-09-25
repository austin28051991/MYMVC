using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
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

        public IApplicationUserRespository ApplicationUser { get; private set; }

        public ICartRespository Cart { get; private set; }

        public IOrderHeaderRespository OrderHeader { get; private set; }

        public IOrderDetailRespository OrderDetail { get; private set; }

        public UnitOfWork(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            Category = new CategoryRepository(dBContext);
            Product = new ProductRepository(dBContext);
            ApplicationUser = new ApplicationUserRepository(dBContext);
            Cart = new CartRepository(dBContext);
            OrderHeader = new OrderHeaderRepository(dBContext);
            OrderDetail = new OrderDetailRepository(dBContext);
        }


        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
