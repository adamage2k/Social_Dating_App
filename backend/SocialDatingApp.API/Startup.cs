using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SocialDatingApp.Application.Account.Interfaces;
using SocialDatingApp.Application.Helpers;
using SocialDatingApp.Application.Repositories;
using SocialDatingApp.Application.Services;
using SocialDatingApp.Application.Users;
using SocialDatingApp.Application.Users.Interfaces;
using SocialDatingApp.Core;
using SocialDatingApp.Core.Entities;
using SocialDatingApp.Infrastructure.Data;
using SocialDatingApp.Infrastructure.Helpers;
using SocialDatingApp.Infrastructure.Middlewares;
using SocialDatingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.API
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

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialDatingApp.API", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:Key").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialApp")));

            services.AddIdentity<User, Role>(options => options.Stores.MaxLengthForKeys = 128)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IConnectionRepository, ConnectionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialDatingApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Seeder.SeedData(app);
        }
    }
}
