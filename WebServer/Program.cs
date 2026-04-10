using System.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// app.MapGet("/", () => "Привет от ИСП - 231! Автор: ");

app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет, {name}!");

app.Run();