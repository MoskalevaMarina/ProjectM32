using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectM32.Models;
using ProjectM32.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectM32.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILogRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            Request request = new Request()
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = context.Request.Host.Value + context.Request.Path
                };

            _repo.AddLog(request);
            // Для логирования данных о запросе используем свойста объекта HttpContext
          //  Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
           
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

       
    }
}
