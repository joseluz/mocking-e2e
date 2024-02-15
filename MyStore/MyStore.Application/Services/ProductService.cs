using MyStore.Application.Connectors;
using MyStore.Application.Model;
using MyStore.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IFreeMarketConnector freeMarketConnector;

        public async Task<IList<Product>> FindAll()
        {
            return new List<Product>()
            {
                new()
                {
                    Id="P1",
                    CurrentValue=12,
                    Name="Product 1"
                },
                new()
                {
                    Id="P2",
                    CurrentValue=14,
                    Name="Product 2"
                }
            };
        }

        //public ProductService(IProductRepository productRepository, IFreeMarketConnector freeMarketConnector)
        //{
        //    this.productRepository = productRepository;
        //    this.freeMarketConnector = freeMarketConnector;
        //}
    }
}
