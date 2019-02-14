using AspNetCoreDapper.Data.Context;
using AspNetCoreDapper.Data.Mappings;
using AspNetCoreDapper.Domain.Interfaces;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreDapper.Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SqlConnection conn;

        public BaseRepository()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new CategoryMap());
                    c.AddMap(new ProductMap());
                    c.ForDommel();
                });
            }
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            conn = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public void Add(TEntity obj)
        {
            conn.Insert(obj);
        }

        public void Delete(TEntity obj)
        {
            conn.Delete(obj);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            //conn.Where(predicate).ToList().ForEach(del => conn.Delete(del));
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return conn.GetAll<TEntity>();
        }

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await conn.GetAsync<TEntity>(id);
        }

        public virtual TEntity GetById(int id)
        {
            return conn.Get<TEntity>(id);
        }

        public void Update(TEntity obj)
        {
            conn.Update(obj);
        }
    }
}
