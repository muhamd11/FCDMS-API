using Api.Middlewares;
using API;
using App.Core;
using App.Core.Interfaces.General.Scrutor;
using App.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    // This method gets called by the runtime. Use this method to add services to the container.
    builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    {
        //To Remove Null
        options.SerializerSettings.ContractResolver = new NullToEmptyStringResolver();
        //To Return Big Json
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //TrimmingString
        options.SerializerSettings.Converters.Add(new TrimmingStringConverter());
    });

    // DB Context
    var DBConnection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DBConnection, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

    //services
    var assembly = typeof(Program).Assembly;
    builder.Services.Scan(s => s.FromAssemblies(assembly)
    .AddClasses(c => c.AssignableTo<ITransientService>())
    .AsImplementedInterfaces()
    .WithTransientLifetime());
    
    builder.Services.Scan(s => s.FromAssemblies(assembly)
    .AddClasses(c => c.AssignableTo<ITransientServiceT<object>>())
    .AsImplementedInterfaces()
    .WithTransientLifetime());
    builder.Services.Scan(s => s.FromAssemblies(assembly)
    .AddClasses(c => c.AssignableTo<ISingletonService>())
    .AsImplementedInterfaces()
    .WithSingletonLifetime());
    builder.Services.Scan(s => s.FromAssemblies(assembly)
    .AddClasses(c => c.AssignableTo<IScopedService>())
    .AsImplementedInterfaces()
    .WithScopedLifetime());
    //custome services
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddAutoMapper(typeof(Program));
    //to privent modle valid
    builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
    //HttpContextAccessor
    builder.Services.AddHttpContextAccessor();

    //Enable CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseMiddleware<ExceptionMiddleware>();

    // Enable CORS 
    app.UseCors("AllowAll");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}