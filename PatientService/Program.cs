using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PatientService.Core.Abstractions.Repositories;
using PatientService.DataAccess.Repositories;
using PatientService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddDbContext<DataContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString")));

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Patients Service";
    options.Version = "1.0";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUi3(x =>
    {
        x.DocExpansion = "list";
    });
}

app.UseHsts();
app.UseRouting();
app.UseOpenApi();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();

