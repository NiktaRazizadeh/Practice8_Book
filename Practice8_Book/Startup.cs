using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Practice8_Book.DataBase;
using Practice8_Book.Models;
using Practice8_Book.Repasitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppBookContext>(o => { o.UseSqlServer(Configuration.GetConnectionString("BookA")); });
            services.AddControllers();
            services.AddTransient<IRepasitory<Book>, BRepasitory<Book>>();
            services.AddTransient<IRepasitory<Author>, BRepasitory<Author>>();
            services.AddTransient<IRepasitory<Publications>, BRepasitory<Publications>>();
            services.AddTransient<IRepasitory<Category>, BRepasitory<Category>>();
            services.AddTransient<IRepasitory<BookAuthor>, BRepasitory<BookAuthor>>();
            services.AddTransient<IRepasitory<BookCategory>, BRepasitory<BookCategory>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
