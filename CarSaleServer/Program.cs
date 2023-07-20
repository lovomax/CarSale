global using CarSale.Data;
global using Microsoft.EntityFrameworkCore;
using CarSaleBackEnd.Data;
using CarSaleBackEnd.Models;
using CarSaleBackEnd.Services.CarService;
using CarSaleBackEnd.Services.ImageService;
//using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace CarSale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme e.g. \"Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>(); 
            });

            //CORS

            var origins = "_origins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: origins,
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:3000")
                            .WithMethods("PUT", "DELETE", "GET").AllowCredentials();
                            policy.WithHeaders(HeaderNames.ContentType);
                            policy.WithHeaders(HeaderNames.Authorization).AllowCredentials();
                            
                        });
            });

            //END CORS

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(origins);

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}