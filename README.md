# Лабораторная работа №27. Знакомство с ASP.NET Core: первый веб-сервер на C#

---

## Основаня информация 

**ФИО:** Гвоздева В.А, Деушев Т.Т
**Группа:** ИСП-231
**Дата:** 16.04.2026

---

## Описание работы

В ходе лабораторной работы были изучены основы создания веб-серверов на платформе `ASP.NET Core`. Рассмотрены следующие темы:
- Установка и настройка .NET SDK
- Создание минимального веб-приложения
- Маршрутизация HTTP-запросов
- Работа с параметрами маршрута
- Обработка ошибок и статуса ответа

---

## Структура проекта

- Lab27_AspNetCore_Gvozdeva_Deushev/
    - img/
        - step5_firstRunLab27_Gvozdeva_Deushev.png
        - step6_routingLab27_Gvozdeva_Deushev.png
        - step7_jsonLab27_Gvozdeva_Deushev.png
        - step8_middlewareLab27_Gvozdeva_Deushev.png
        - step9_finalLab27_1_Gvozdeva_Deushev.png
        - step9_finalLab27_2_Gvozdeva_Deushev.png
        - step9_finalLab27_3_Gvozdeva_Deushev.png
    - WebServer/
        - Properties/
            - launchSettings.json
        - appsettings.Development.json
        - appsettings.json
        - Program.cs
        - WebServer.csproj
    - .editorconfig
    - .gitignore
    - README.md

---

## Список реализованных маршрутов с описанием

|Маршрут|Метод|Описанние|Пример ответа|
|:------|:-----|:-------|:------------|
|`/`|GET|Приветственное сообщение с текущим временем|`{ Message = "Добро пожаловать!", Version = "1.0", Time = DateTime.Now.ToString("HH::mm:ss") }`|
|`/me`|GET|Информация о студенте|`{ Name = "Гвоздева Вероника", Group = "ИСП-231", Year = 3, Skills = new[] { "C#", "HTML", "CSS", "JS", "ASP.NET" } }`|
|`/calc/{a}/{b}`|GET|Калькулятор|`{ A = a, B = b, Sum = a + b, Diff = a - b, Mul = a * b, Div = b != 0 ? a / b : 0, }`|
|`/student`|GET|Информация о студенте|`{ Name = "Гвоздева Вероника", Group = "ИСП-231", Year = 3, IsActive = true }`|
|`/subjects`|GET|Список предметов|`{ "РПМ", "РМП", "ИСРПО", "СП" }`|
|`/hello/{name}`|GET|Приветствие пользователя|`$"Привет, {name}!"`|
|`/time`|GET|Текущее время на сервере|`$"Время на сервере: {DateTime.Now}"`|
|`/about`|GET|Информация о сервере|`"Это мой первый ASP.NET Core сервер"`|

---

## Главные выводы

1. **ASP.NET Core** - это современный, кроссплатформенный фреймворк от Microsoft для создания веб-приложений и API. Он работает поверх платформы .NET и заменяет устаревший ASP.NET Framework
2. **Minimal API** упрощает создание микросервисов. В отличие от MVCM Minimal API требует минимум кода для запуска веб-сервиса и идельно подходит для небольших проектов, API и микросервисов.
3. **Middleware** - это цепочка функций, через которую проходит каждый HTTP-запрос, прежде чем дойдёт до обработчика. Это аналог цепочки фильтров.

---

## Итоговая таблица:

|Характеристика|ASP.NET Core|
|:------------|:----------|
|**Создание сервера**|WebApplication.CreateBuilder()|
|**Запуск**|app.Run()|
|**Маршрут GET**|app.MapGet("/", fn)|
|**Параметр маршрута**|{name} → (string name)|
|**Возврат JSON**|return new {...} / Results.Ok(...)|
|**Middleware**|app.Use(async (ctx, next) => ...)|
|**Логирование**|Встроенное + Console.WriteLine|
|**Статус ответа**|Results.NotFound(...)|
|**Тип данных**|Строгие (C# record, class)|

---

## Интересные факты

ASP.NET Core используется в крупных проектах по всему миру:
|Компания/Проект|Масштаб|Что использует|
|:-------------:|:-----:|:------------:|
|**Microsoft.com**|Весь сайт Microsoft|Полностью переписан на ASP.NET Core|
|**JetBrains**|YouTrack, TeamCity|API и веб-интерфейсы|
|**Stack Overflow**|50+ миллионов посетителей/мес|Весь сайт|

---

## Ответьте на вопросы:

1. Чем Minimal API отличается от MVC в ASP.NET Core?:
    - **Minimal API** - быстрый старт для маленьких проектов
    - **MVC** - полноценная структура для больших приложений
2. Что произойдёт, если поставить app.MapGet(...) до app.Use(...)?:
    - **Middleware** не будет выполняться для этих маршрутов. 
3. Почему ASP.NET Core преобразует PascalCase в camelCase при сериализации JSON?:
    - Чтобы соответствовать стандартам JavaScripr/JSON, где принято использовать camelCase.
4. Что означает код ответа HTTP 401? А 404? А 200?
    |Диапазон|Категория|Пример|
    |:------:|:-----:|:----:|
    |2xx|Успех|200 OK, 201 Created|
    |4xx|Ошибка клиента|401 Unauthorized, 404 Not Found|
    |5xx|Ошибка сервера|500 Server Error|
5. Чем dotnet run отличается от dotnet watch run?:
    |**Характеристика**|`dotnet run`|`dotnet watch run`|
    |:-----------------|:----------:|:----------------:|
    |**Автоперезапуск**|Нет|Да|
    |**Скорость разработки**|Медленнее|Быстрее|
    |**Для чего**|Финальный запуск|Активная разработка|