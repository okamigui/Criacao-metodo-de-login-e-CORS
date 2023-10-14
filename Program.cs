using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ExoContext, ExoContext>();
builder.Services.AddControllers();
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = "JwtBearer";
//     options.DefaultChallengeScheme = "JwtBearer";
// })
// // Parâmetros de validacão do token.
// .AddJwtBearer("JwtBearer", options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         // Valida quem está solicitando.
//         ValidateIssuer = true,
//         // Valida quem está recebendo.
//         ValidateAudience = true,
//         // Define se o tempo de expiração será validado.
//         ValidateLifetime = true,
//         // Criptografia e validação da chave de autenticacão.
//         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao")),
//         // Valida o tempo de expiração do token.
//         ClockSkew = TimeSpan.FromMinutes(30),
//         // Nome do issuer, da origem.
//         ValidIssuer = "exoapi.webapi",
//         // Nome do audience, para o destino.
//         ValidAudience = "exoapi.webapi"
//     };
// });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
