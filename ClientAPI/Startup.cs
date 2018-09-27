using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Bootstrapper;
using ClientAPI.DataAccessTier;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClientAPI {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            var key = System.Text.Encoding.ASCII.GetBytes (Configuration.GetSection ("Jwt:Key").Value);
            
            services.AddDbContext<DataContext> (db => db.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));
           
            services.AddIdentity<Models.ApplicationUser, IdentityRole>(
                x => {
                                       
                    x.Password.RequireUppercase = false;                    
                    x.Password.RequireLowercase = false;
                    x.Password.RequireDigit = false;
                    x.Password.RequiredLength = 4;
                    x.SignIn.RequireConfirmedEmail = false;
                    x.SignIn.RequireConfirmedPhoneNumber = false;
                }
            ).AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

             services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (options => 
            {
                    
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {         
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),                  
                        ValidIssuer = Configuration["Jwt:JwtIssuer"],
                        ValidAudience = Configuration["Jwt:JwtIssuer"]     
                    };

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });

            services.AddCors (options => {
                options.AddPolicy ("AllowAll", p => {
                    p.AllowAnyOrigin ()
                        .AllowAnyHeader ()
                        .AllowAnyMethod ()
                        .AllowCredentials ();
                });
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, IServiceProvider sPovider) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseStaticFiles();
            app.UseAuthentication();
            
            app.UseMvc ();
            
            new RoleSeeder(sPovider).SeedRoles().Wait();
            

           
        }
    }
}