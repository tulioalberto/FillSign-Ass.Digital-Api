using FillSign.Ds.Api.Configuration;
using FillSign.Ds.Application.CommandHandlers;
using FillSign.Ds.Data;
using FillSign.Ds.Domain.Entities;
using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddApiConfig()
       .AddCorsConfig()
       .AddSwaggerConfig()
       .AddDbContextAndNotificationScopeConfig()
       .AddIdentityConfig();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();