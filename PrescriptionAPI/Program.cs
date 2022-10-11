using Microsoft.EntityFrameworkCore;
using PrescriptionAPI.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona  servicos para o container.


//Essa e a depedencia  para o  appsettings json
ConfigurationManager configuration = builder.Configuration;

//Registrando o banco de dados!
builder.Services.AddDbContext<PrescriptionDataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IPrescriptionRepository , PrescriptionRepository>();

//Registrando AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurando a requisição pipeline HTTP!
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
