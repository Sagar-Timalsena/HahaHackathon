﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using WhiteLagoon.Domain.Entities;

//namespace WhiteLagoon.Application.Common.Interfaces
//{
//    public interface IVillaRepository
//    {
//        IEnumerable<Villa>GetAll(Expression<Func<Villa,bool>>? filter=null, string? includeproperties=null);
//        Villa Get(Expression<Func<Villa, bool>>? filter, string? includeproperties = null);
//        void Add(Villa entity);
//        void Update(Villa entity);

//        void Remove(Villa entity);
//        void Save();


//    }

//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IVillaRepository :IRepository<Villa>
    {
       
        void Update(Villa entity);

         void Save();


    }

}
