using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using User.Application;
using User.Infra.Data;
using User.Infra.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.ApplicationExtension();
builder.Services.InfraServiceExtensions(builder.Configuration);
builder.Services.InfraDataExtensions(builder.Configuration);

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();