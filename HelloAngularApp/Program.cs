using GraphQL;
using HelloAngularApp.Models.Context;
using HelloAngularApp.Models.GraphQL;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Splat;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=qaz123";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
builder.Services.AddScoped<HelloAngularAppSchema>();
//builder.Services.AddGraphQL(x =>
//    {
//        x.ExposeExceptions = true;
//    }).AddGraphTypes(ServiceLifetime.Scoped);

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist/portal";
});

var app = builder.Build();

app.UseRouting();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();