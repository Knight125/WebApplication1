using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAPITemplate.Services
{
    interface IProductRepository
    {
        Task<IEnumerable<GDPData>> GetAllGDPData();
    }
}
