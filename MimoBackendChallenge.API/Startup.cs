using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Services;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.DAL.Mappings;
using MimoBackendChallenge.DAL.Repositories;
using MimoBackendChallenge.Database;

namespace MimoBackendChallenge.API
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
            services.AddMvc(c => c.EnableEndpointRouting = false);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MimoBackendChallengeApi", Version = "v1" });
            });

            services.AddDbContext<MimoContext>(options => { 
                options.UseSqlite("Data Source=mimo.db");
                options.UseLazyLoadingProxies();
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // This one can be used in a pure form, altought it is not recommended
            services.AddScoped(typeof(ISimpleDALService<,>), typeof(SimpleDALService<,>));

            services.AddSingleton(s => new ModelMapper().Instance);

            services.AddTransient<ILessonsRepository, LessonsRepository>();
            services.AddTransient<IChaptersRepository, ChaptersRepository>();
            services.AddTransient<ICoursesRepository, CoursesRepository>();
            services.AddTransient<IUserLessonsRepository, UserLessonsRepository>();

            services.AddTransient<ILessonsService, LessonsService>();
            services.AddTransient<IUserLessonsService, UserLessonsService>();
            services.AddTransient<IChaptersService, ChaptersService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<IObjectiveEvaluator, ObjectiveEvaluator>();
            services.AddTransient<IObjectivesService, ObjectivesService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MimoBackendChallengeApi");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc();
        }
    }
}
