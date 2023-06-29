using BooksLife.Core;
using BooksLife.Database;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies()
                                  .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IAuthorManager, AuthorManager>();
            builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
            builder.Services.AddTransient<IReaderManager, ReaderManager>();
            builder.Services.AddTransient<IReaderRepository, ReaderRepository>();
            builder.Services.AddTransient<IViewModelMapper, ViewModelMapper>();
            builder.Services.AddTransient<IBookRepository, BookRepository>();
            builder.Services.AddTransient<IBookManager, BookManager>();
            builder.Services.AddTransient<IBookTitleManager, BookTitleManager>();
            builder.Services.AddTransient<IBookTitleRepository, BookTitleRepository>();
            builder.Services.AddTransient<IBorrowManager, BorrowManager>();
            builder.Services.AddTransient<IBorrowRepository, BorrowRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}