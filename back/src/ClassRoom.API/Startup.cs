using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Application.Contratos;
using ClassRoom.Application;
using ClassRoom.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ClassRoom.Persistence.Contratos;
using System.Text.Json.Serialization;
using ClassRoom.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ClassRoom.API
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
            services.AddDbContext<ClassRoomContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Defalt"))
            );

            services.AddIdentityCore<User>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;
                })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<ClassRoomContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters 
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                    );

            services.AddControllers()
                    .AddJsonOptions(options => 
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                    )
                    .AddNewtonsoftJson( options => options.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IBlocoService, BlocoService>();
            services.AddScoped<IAulaService, AulaService>();           
            services.AddScoped<ITokenService, TokenService>();           
            services.AddScoped<IAccountService, AccountService>();
                       
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IBlocoPersist, BlocoPersist>();
            services.AddScoped<IAulaPersist, AulaPersist>();         
            services.AddScoped<IUserPersist, UserPersist>();

            services.AddCors();
            services.AddSwaggerGen(options =>

            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassRoom.API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWTf Authorization header usando Bearer.
                                    Entre com 'Bearer' [espaço] então coloque seu token.
                                    Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {   
                    {                                               
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<String>()
                        }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassRoom.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions(){
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
