using AspNetCoreDapper.Domain.Entities;
using AspNetCoreDapper.Domain.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDapper.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public override IEnumerable<Product> GetAll() =>
            conn.Query<Product, Category, Product>(
                @"SELECT * FROM tbl_product INNER JOIN tbl_category ON tbl_product.CategoryId = tbl_category.Id",
                map: (product, category) =>
                {
                    product.Category = category;
                    return product;
                });

        public override Product GetById(int id) =>
            conn.Query<Product, Category, Product>(
                @"SELECT TOP(1) * FROM tbl_product 
                    INNER JOIN tbl_category ON 
                    tbl_product.CategoryId = tbl_category.Id
                    WHERE tbl_product.Id = @Id",
                map: (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                param: new { Id = id }).FirstOrDefault();
        
    }
}
