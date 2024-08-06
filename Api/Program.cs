using Api.Middlewares;
using API;
using App.Core;
using App.Core.Interfaces.General.Scrutor;
using App.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

builder.Services.AddControllers();

// This method gets called by the runtime. Use this method to add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    //To Remove Null
    options.SerializerSettings.ContractResolver = new NullToEmptyStringResolver();
    //To Retun Big Jason
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    //TrimmingString
    options.SerializerSettings.Converters.Add(new TrimmingStringConverter());
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Add Serilog to the logging pipeline
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(Program));

//services
var assembly = typeof(Program).Assembly;

builder.Services.Scan(s => s.FromAssemblies(assembly)
.AddClasses(c => c.AssignableTo<ITransientService>())
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

builder.Services.AddHttpContextAccessor();

// to not Valid
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//TODO: Disable in production
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();