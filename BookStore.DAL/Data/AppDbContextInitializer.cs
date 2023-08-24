using System.Text.Json;
using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DAL.Data;

public static class AppDbContextInitializer
{
    public static void DatabaseInitialize(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext? context)
    {
        if (!context!.Set<Book>().Any())
        {
            var booksData = File.ReadAllText("../BookStore.DAL/Data/TestData/books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(booksData);

            if (books is not null)
            {
                foreach (var item in books)
                    context.Set<Book>().Add(item);
                
                context.SaveChangesAsync();
            }
        }
    }
}