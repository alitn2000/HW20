using App.Domain.AppServices.CarModelAggrigate;
using App.Domain.AppServices.OperatorAggrigate;
using App.Domain.AppServices.RejectedRequestAggrigate;
using App.Domain.AppServices.TechExamAggrigate;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts;
using App.Domain.Core.TurnsManager.RejectedRequestsAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Services.TurnsManager.CarModelServices;
using App.Domain.Services.TurnsManager.OperatorServices;
using App.Domain.Services.TurnsManager.RejectedRequestServices;
using App.Domain.Services.TurnsManager.TechExamServices;
using App.Infra.Data.SqlService.Ef;
using App.Infra.DataAccess.EF.CarModelAggrigate;
using App.Infra.DataAccess.EF.OperatorAggrigate;
using App.Infra.DataAccess.EF.RejectedRequestAggrigate;
using App.Infra.DataAccess.EF.TechExamAggrigate;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("TurnsDb");
builder.Services.AddDbContext<TurnsDb>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<ITechExamRepository, TechExamRepository>();
builder.Services.AddScoped<ITechExamService, TechExamService>();
builder.Services.AddScoped<ITechExamAppService, TechExamAppService>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();
builder.Services.AddScoped<IRejectedRequestRepository, RejectedRequestRepository>();
builder.Services.AddScoped<IRejectedRequestService, RejectedRequestService>();
builder.Services.AddScoped<IRejectedRequestAppService, RejectedRequestAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TechExam}/{action=AddExam}/{id?}");

app.Run();
