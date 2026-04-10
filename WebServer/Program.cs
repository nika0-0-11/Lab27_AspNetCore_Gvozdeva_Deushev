using System.Data;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// app.MapGet("/", () => "Привет от ИСП - 231! Автор: ");

app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет, {name}!");

app.MapGet("/student", () => new
{
    Name = "Гвоздева Вероника",
    Group = "ИСП-231",
    Year = 3,
    IsActive = true
});

app.MapGet("/subjects", () => new[]
{
    "РПМ",
    "РМП",
    "ИСРПО",
    "СП"
});

app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,
    Name: $"Товар #{id}",
    Price: id * 99.909m,
    InStock: id % 2 == 0
));


app.Run();

record Product(int Id, string Name, decimal Price, bool InStock);