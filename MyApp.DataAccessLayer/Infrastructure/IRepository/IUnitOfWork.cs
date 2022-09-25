using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRespository Category { get; }
        IProductRespository Product { get; }

        IApplicationUserRespository ApplicationUser { get; }

        ICartRespository Cart { get; }

        IOrderHeaderRespository OrderHeader { get; }

        IOrderDetailRespository OrderDetail { get; }

        void save();
    }
}
