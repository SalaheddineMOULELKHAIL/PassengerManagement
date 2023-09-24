using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PassengerManagement.Entities;
using PassengerManagement.Services;
using System;
using System.Collections.Generic;

namespace PassengerManagement.Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                })
               .AddScoped<IPassengerManagementService, PassengerManagementService>() 
               .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            var service = serviceProvider.GetService<IPassengerManagementService>();

            List<Family> families = service.CheckRulesAndGetFamilies(Extensions.GetPassengers());
            decimal optimizedTurnover = service.GetOptimizedTurnover(families, Extensions.AvailablePlace);

            Console.WriteLine(string.Format(Extensions.OptimizedTurnoverMessage, optimizedTurnover));
        }
    }
}
