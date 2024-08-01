using App.Core;
using App.Core.Interfaces.General.Scrutor;
using App.EF;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Disable automatic model state validation
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//TODO: Disable in production
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();