using CleanArchMvc.Infra.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureAPI(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson(x =>
x.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//builder.Services.AddControllers().AddJsonOptions(opt =>
//{
//    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.Run();
