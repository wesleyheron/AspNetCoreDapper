using AspNetCoreDapper.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreDapper.Data.Mappings
{
    public class CategoryMap : DommelEntityMap<Category>
    {
        public CategoryMap()
        {
            ToTable("tbl_category");
            Map(p => p.Id).IsKey().IsIdentity();
        }
        //public void Configure(EntityTypeBuilder<Category> builder)
        //{
        //    builder.ToTable("tbl_category");

        //    builder.HasKey(c => c.Id);

        //    builder.Property(c => c.Name)
        //        .IsRequired()
        //        .HasColumnName("Name")
        //        .HasColumnType("varchar(50)");

        //    builder.HasMany(te => te.Products)
        //        .WithOne(e => e.Category)
        //        .HasForeignKey(te => te.CategoryId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //}
    }
}
