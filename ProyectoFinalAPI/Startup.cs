using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using Services.Interfaces;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoFinalAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCORS", builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("SECRET"))),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DBContext"));
            });

            services.AddScoped<IAuth, AuthRepo>();
            services.AddScoped<StatusRepo>();
            services.AddScoped<UserRepo>();
            services.AddScoped<RoleRepo>();
            services.AddScoped<UserRoleRepo>();
            services.AddScoped<LogRepo>();
            services.AddScoped<AddressRepo>();
            services.AddScoped<InstitutionRepo>();
            services.AddScoped<TeacherInstitutionRepo>();
            services.AddScoped<StudentInstitutionRepo>();
            services.AddScoped<SubjectRepo>();
            services.AddScoped<SectionHeaderRepo>();
            services.AddScoped<SectionDetailRepo>();
            services.AddScoped<PiServerRepo>();
            services.AddScoped<LicenseRepo>();
            services.AddScoped<FileRepo>();
            services.AddScoped<ExerciseRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoFinalAPI v1"));
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
