﻿//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using WhiteLagoon.Application.Common.Interfaces;
//using WhiteLagoon.Domain.Entities;
//using WhiteLagoon.Infrastructure.Data;

//namespace WhiteLagoon.Infrastructure.Repository
//{
//    public class VillaRepository : IVillaRepository
//    {
//        private readonly ApplicationDbContext _db;

//        public VillaRepository(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public void Add(Villa entity)
//        {
//            _db.Add(entity); 
//                }

//        public Villa Get(Expression<Func<Villa, bool>>? filter, string? includeproperties = null)
//        {
//            IQueryable<Villa> query = _db.Set<Villa>();
//            if (filter != null)
//            {
//                query = query.Where(filter);
//            }
//            if (!string.IsNullOrEmpty(includeproperties))
//            {
//                foreach (var includeprop in includeproperties
//                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                {
//                    query = query.Include(includeprop);
//                }
//            }
//            return query.FirstOrDefault();
//        }

//        public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeproperties = null)
//        {
//            IQueryable<Villa> query = _db.Set<Villa>();
//            if (filter != null)
//            {
//                query = query.Where(filter);    
//            }
//            if(!string.IsNullOrEmpty(includeproperties))
//            {
//                foreach(var includeprop in includeproperties
//                  .Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries ))
//                {
//                    query = query.Include(includeprop);
//                }
//            }
//            return query.ToList();
//                }

//        public void Remove(Villa entity)
//        {
//            _db.Remove(entity);        
//        }

//        public void Save()
//        {
//            _db.SaveChanges();        }

//        public void Update(Villa entity)
//        {
//            _db.Update(entity);
//            //_db.Villas.Update(entity); not needed

//        }
        //not needed
        //Villa IVillaRepository.Get(Expression<Func<Villa, bool>>? filter, string? includeproperties)
        //{
        //    throw new NotImplementedException();
        //}
//    }
//}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Villa entity)
        {
            _db.Villas.Update(entity);
 
        }
    }
}