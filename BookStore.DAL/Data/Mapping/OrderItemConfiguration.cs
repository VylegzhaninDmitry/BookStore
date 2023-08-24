using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Data.Mapping;

public class OrderItemConfiguration: IEntityTypeConfiguration<OrderBook>
{
    public void Configure(EntityTypeBuilder<OrderBook> builder)
    {
        builder.Property(b => b.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(b => b.OrderId)
            .HasColumnName("order_id")
            .IsRequired();
        
        builder.Property(b => b.BookId)
            .HasColumnName("book_id")
            .IsRequired();

        builder.HasOne(b => b.Order)
            .WithMany(o => o.OrderBooks)
            .HasForeignKey(o => o.OrderId);

        builder.HasOne(b => b.Book)
            .WithMany(o => o.OrderBooks)
            .HasForeignKey(o => o.BookId);
    }
}