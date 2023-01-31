using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Config;
using Blog.Repository.Abstract;
using Blog.Repository.Concrete;
using Blogs.Service.Abstract;
using Blogs.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

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

            services.AddDbContext<DBEFContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

            // Add services to the container.
            services.AddSingleton<ConnectionStrings>();
            services.AddSingleton<DBEFContext>(/*s => new DBEFContext(connectionStrings)*/);

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

            app.Run();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "html_pages")),
                RequestPath = "/html"
            });

            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blogs API");
            });
        }
    }
}