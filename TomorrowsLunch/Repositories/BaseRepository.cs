using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;


namespace TomorrowsLunch.Repositories
{
    public class BaseRepository<TEntity> : IRepository where TEntity : BaseEntity
    {
        public object Create(object data)
        {
            try
            {
                if (data is TEntity)
                {
                    TEntity newData = null;
                    using (var context = new ApplicationDbContext())
                    {
                        newData = context.Set<TEntity>().Add((TEntity)data);
                        context.SaveChanges();
                    }
                    return data;
                }
                else
                {
                    return data;
                }
            }
            catch (Exception)
            {
                return data;
            }
        }
        //public List<TEntity> GetAll()
        //{
        //    IQueryable<TEntity> meals;
        //    var mealsList = new List<TEntity>();
        //    using (var db = new ApplicationDbContext())
        //    {
        //        meals = db.Set<TEntity>().Include(m => m.Ingredients).Where(m => !m.Deleted);
        //        mealsList = meals.ToList();
        //    }
        //    return mealsList;
        //}
        //public object GetSpecific(Guid id)
        //{
        //    TEntity data = null;
        //    try
        //    {
        //        using (var context = new ApplicationDbContext())
        //        {
        //            data = context.Set<TEntity>().Where(x => x.Id == id).Single();
        //        }
        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        return data;
        //    }
        //}
        public object Update(object data)
        {
            try
            {
                if (data is TEntity)
                {
                    TEntity model = data as TEntity;
                    using (var context = new ApplicationDbContext())
                    {
                        context.Set<TEntity>().Attach(model);
                        context.Entry(model).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    return data;
                }
                else
                {
                    return data;
                }
            }
            catch (Exception)
            {
                return data;
            }
        }
        

        public object Delete(object data)
        {
            ((TEntity)data).Deleted = true;
            return Update(data);
        }
    }
    public interface IRepository
    {
        object Create(object data);
        object Update(object data);
        object Delete(object data);

    }
}