using System.Text.Json.Serialization;
using APICatalogo.Data;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Interface;
using APICatalogo.Loggin;
using APICatalogo.Mapping;
using APICatalogo.Repository;
using APICatalogo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando o CustomLoggerProvider com configuração personalizada
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
{
    LogLevel = LogLevel.Information,
}));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

string mysqlConection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseMySql(mysqlConection,
        ServerVersion.AutoDetect(mysqlConection)
        );
});


builder.Services.AddTransient<IMeuServicoe, MeuServico>();
builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProdutoDTOAutoMappingProfile>();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFIlter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddNewtonsoftJson();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
