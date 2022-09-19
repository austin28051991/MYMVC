using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICartRespository:IRepository<Cart>
    {

        int IncreamentCartItem(Cart cart, int count);
        int DecreamentCartItem(Cart cart, int count);


    }
}
