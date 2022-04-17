using CustomerList;
using CustomerList.Models;
using CustomerList.Factories;
using CustomerList.Factories.Interfaces;
using CustomerList.Services;
using CustomerList.Services.Interfaces;
using CustomerList.UserInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var appOptions = configuration
    .GetSection(AppOptions.AppOptionsSectionName)
    .Get<AppOptions>();

var serviceProvider = new ServiceCollection()
    .AddSingleton(appOptions)
    .AddSingleton<Application>()
    .AddSingleton<IApplicationSteps, ApplicationSteps>()
    .AddSingleton<IUserInterface, ConsoleUserInterface>()
    .AddSingleton<IFileParsingService, FileParsingService>()
    .AddSingleton<IFileService, FileService>()
    .AddSingleton<ICustomerService, CustomerService>()
    .AddSingleton<ICustomerSorterFactory, CustomerSorterFactory>()
    .BuildServiceProvider();

var application = serviceProvider.GetRequiredService<Application>();

application.Run();
