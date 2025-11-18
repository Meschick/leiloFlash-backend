using leiloFlash_backend.Config;
using leiloFlash_backend.Data;
using leiloFlash_backend.Hubs;
using leiloFlash_backend.Repositories.Lance;
using leiloFlash_backend.Repositories.Leilao;
using leiloFlash_backend.Repositories.Lote;
using leiloFlash_backend.Repositories.Usuario;
using leiloFlash_backend.Repositories.Veiculo;
using leiloFlash_backend.Services;
using leiloFlash_backend.Services.Auth;
using leiloFlash_backend.Services.Auth.Security;
using leiloFlash_backend.Services.Lance;
using leiloFlash_backend.Services.Leilao;
using leiloFlash_backend.Services.Lote;
using leiloFlash_backend.Services.Pagamento;
using leiloFlash_backend.Services.Usuario;
using leiloFlash_backend.Services.Veiculo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);                                                                                                                                                   

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAppCors(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSignalR();

// Variável de conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adicionar serviço do SQL Server
builder.Services.AddDbContext<LeiloDbContext>(options => options.UseSqlServer(connectionString));

// Adicionar Serviços
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISenhaService, SenhaService>();
builder.Services.AddScoped<ILeilaoService, LeilaoService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<ILanceService, LanceService>();
builder.Services.AddScoped<ILoteService, LoteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();



// Adicionar Repositories
builder.Services.AddScoped<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ILoteRepository, LoteRepository>();
builder.Services.AddScoped<ILanceRepository, LanceRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAppCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<LanceHub>("/lancesHub");

app.Run();
