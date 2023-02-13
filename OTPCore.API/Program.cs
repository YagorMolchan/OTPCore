using Microsoft.EntityFrameworkCore;
using OTPCore.DAL.EFCore;
using OTPCore.DAL.Interfaces;
using OTPCore.DAL.Repositories;
using OTPCore.BLL.Profiles;
using Newtonsoft.Json;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddTransient<IPositionRepository, PositionReposiory>();
builder.Services.AddScoped<IOTPUnitOfWork,OTPUnitOfWork>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<EmployeeProfile>();
    mc.AddProfile<PositionProfile>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OTPDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

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

app.Run();
