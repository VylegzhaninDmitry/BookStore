using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Data.Mapping;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .Property(b => b.Id)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(b => b.CreatedOn)
            .HasColumnName("created_on")
            .IsRequired();

        builder
            .Property(b => b.TotalPrice)
            .HasColumnName("total_price")
            .IsRequired();

        builder
            .HasMany(b => b.OrderBooks)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);


    }
}