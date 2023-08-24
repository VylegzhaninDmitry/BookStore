using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Data.Mapping;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .Property(b => b.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder
            .Property(b => b.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(b => b.Author)
            .HasColumnName("author")
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(b => b.PublishedDate)
            .HasColumnName("published_date")
            .IsRequired();
        
        builder
            .Property(b => b.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)");
        
        builder
            .HasMany(b => b.OrderBooks)
            .WithOne(o => o.Book)
            .HasForeignKey(o => o.BookId);
    }
}