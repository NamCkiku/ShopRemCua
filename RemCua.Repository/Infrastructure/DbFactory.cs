using RemCua.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCua.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopRemCuaEntity dbContext;

        public ShopRemCuaEntity Init()
        {
            return dbContext ?? (dbContext = new ShopRemCuaEntity());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
