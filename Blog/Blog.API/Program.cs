using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Config;
using Blog.Repository.Abstract;
using Blog.Repository.Concrete;
using Blogs.Service.Abstract;
using Blogs.Service.Concrete;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace Blog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args);
        }

       

        public static void CreateHostBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            ConnectionStrings connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            // Add services to the container.
            
            services.AddSingleton<ConnectionStrings>(connectionStrings);
            services.AddSingleton<DBEFContext>(s => new DBEFContext(connectionStrings));

            services.AddSingleton<IDBRepository, DBRepository>();

            services.AddSingleton<IBlogsRepository, BlogsRepository>();

            services.AddSingleton<IBlogsService, BlogService>();



            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            
            //Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:19593").AllowCredentials();
                });
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Blogs API",
                    Description = "Blogs Management API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Amine",
                        Email = "yildizamine95@gmail.com"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Amine Open Licence"
                    }
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "html_pages")),
                RequestPath = "/html"
            });

            app.Run();
        }
    }
}