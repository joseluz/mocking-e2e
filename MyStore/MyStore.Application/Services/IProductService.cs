using MyStore.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services
{
    public interface IProductService
    {
        Task<IList<Product>> FindAll();
    }
}
