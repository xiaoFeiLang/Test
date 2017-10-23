using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lcq.IDAL;
using Lcq.Models;
using System.Data;
using System.Data.Entity;
namespace Lcq.DAL
{
    public class SysSampleRepository : ISysSampleRepository
    {

        //public IQueryable<SysSample> GetList(DBContainer db)
        //{
        //    IQueryable<SysSample> list = db.SysSample.AsQueryable();
        //    return list;
        //}

        //public int Create(SysSample entity)
        //{
        //    using (DBContainer db = new DBContainer())
        //    {
        //        db.Set<SysSample>().Add(entity);
        //        return db.SaveChanges();
        //    }
        //}
    }
}
