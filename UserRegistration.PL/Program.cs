using FluentValidation;
using System.Reflection;
using UserRegistration.BLL;
using UserRegistration.BLL.Models;
using UserRegistration.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddUserRegistrationBLL();
builder.Services.AddUserRegistrationDAL(builder.Configuration);

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.Configure<EmailValidationSettings>(builder.Configuration.GetSection("EmailValidationSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
