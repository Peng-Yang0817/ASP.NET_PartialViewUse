using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_Service.WaterQuality
{
    public class WaterQualityService
    {
        protected DbContext Context { get; private set; }

        public WaterQualityService(DbContext context)
        {
            Context = context;
        }

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }


        /// <summary>
        /// 讀取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            if (funcWhere == null)
            {
                return this.Context.Set<T>();
            }
            else
            {
                return this.Context.Set<T>().Where<T>(funcWhere);
            }

        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Create<T>(T entity) where T : class
        {
            this.Context.Set<T>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public bool Update<T>(T entity) where T : class
        {
            try
            {
                this.Context.Entry(entity).State = EntityState.Modified;
                this.Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class
        {
            this.Context.Set<T>().Remove(entity);
            this.Context.SaveChanges();
        }
    }
}
