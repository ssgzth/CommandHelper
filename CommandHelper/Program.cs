using CommandHelper.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding dependency 
/*builder.Services.AddScoped<ICommandRepo, MockCommandRepo>();*/
builder.Services.AddScoped<ICommandRepo, SqlCommandRepo>();
// Adding the dbcontext for the database connectivity
builder.Services.AddDbContextPool<CommandDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("CommandHelperDbContext")));

//Adding the AutoMapper for DTO
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//service for the json seriealization camel case property resolver
builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
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
