using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Data.SQL92.UnitOfWork;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using BlueLotus360.Web.APIApplication.Services;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlueLotus360.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<ICompanyService,CompanyService>();
            builder.Services.AddScoped<IJwtUtility, BasicJwtHelper>();
           builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseMiddleware<JwtMiddleware>();

            app.Run();
        }
    }
}