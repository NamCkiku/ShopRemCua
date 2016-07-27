using RemCua.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCua.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopRemCuaEntity Init();
    }
}
