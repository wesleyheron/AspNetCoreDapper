using AspNetCoreDapper.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreDapper.Data.Mappings
{
    public class ProductMap : DommelEntityMap<Product>
    {
        public ProductMap()
        {
            ToTable("tbl_product");
            Map(p => p.Id).IsKey().IsIdentity();
        }
        //public void Configure(EntityTypeBuilder<Product> builder)
        //{
        //    builder.ToTable("tbl_product");

        //    builder.HasKey(c => c.Id);

        //    builder.Property(c => c.Name)
        //        .IsRequired()
        //        .HasColumnName("Name")
        //        .HasColumnType("varchar(50)");

        //    builder.Property(c => c.Price)
        //        .IsRequired()
        //        .HasColumnName("Price")
        //        .HasColumnType("decimal(16 ,3");

        //}
    }
}
