using MyStore.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Connectors
{
    public interface IFreeMarketConnector
    {
        Task<IEnumerable<ProductPriceItem>> SearchPriceTableFor(IEnumerable<string> keys);
    }
}
