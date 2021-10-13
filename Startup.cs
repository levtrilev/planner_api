using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PlannerAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PlannerAPI2.GraphQL;

namespace PlannerAPI2
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlannerAPI2", Version = "v1" });
            });
            services.AddDbContext<TodoDbContext>(options => options.UseSqlServer("User ID=sa;Password=12345;Initial Catalog=Todo;Data Source=HUANAN\\SQLEXPRESS2014"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                 {
                                     options.RequireHttpsMetadata = false;
                                     options.TokenValidationParameters = new TokenValidationParameters
                                     {
                                         // ��������, ����� �� �������������� �������� ��� ��������� ������
                                         ValidateIssuer = true,
                                         // ������, �������������� ��������
                                         ValidIssuer = AuthOptions.ISSUER,

                                         // ����� �� �������������� ����������� ������
                                         ValidateAudience = true,
                                         // ��������� ����������� ������
                                         ValidAudience = AuthOptions.AUDIENCE,
                                         // ����� �� �������������� ����� �������������
                                         ValidateLifetime = true,

                                         // ��������� ����� ������������
                                         IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                                         // ��������� ����� ������������
                                         ValidateIssuerSigningKey = true,
                                     };
                                 });
            services.AddControllers();
            services.AddGraphQLServer()
                .AddQueryType<Queries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlannerAPI2 v1"));
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/graphql");
            });
        }
    }
}
