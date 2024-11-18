
using BookLibrary.Data;
using BookLibrary.Repo.AuthorRepo;
using BookLibrary.Repo.BookRepo;
using BookLibrary.Repo.GenreRepo;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
            builder.Services.AddScoped<IGenreRepo, GenreRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
