using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Commands;
using ToDo.API.ModelWrite;
using ToDo.API.ModelRead;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateTodoCommand).Assembly);

//builder.Services.AddDataAccess();
//builder.Services.AddDataInitializer();
//builder.Services.AddReadModels(Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton<ITodoWriter, TodoWriter>();
builder.Services.AddSingleton<ITodoReader, TodoReader>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapSwagger();

app.Run();
