using ConsoleAppTest.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleAppTest
{

    public static class Program
    {

        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMyService, MyService>();
            serviceCollection.AddSingleton<Model>();
            serviceCollection.AddSingleton<ViewModel>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            AutoMapperStartupTask auto = new AutoMapperStartupTask(serviceProvider);
            auto.Execute();

            Model model = serviceProvider.GetRequiredService<Model>();
            model.SomeValue = 100;
            model.AnotherValue = "10001";
            model.Position.X = 1;
            model.Position.Y = 2;
            model.Position.Z = 3;
            model.Day = WeekDay.Monday;

            Model model2 = MappingExtensions.MapTo<Model, Model>(model);
            model2.Day = WeekDay.Tuesday;
            Console.WriteLine($"model={model}");
            Console.WriteLine($"model2={model2}");

            ViewModel viewModel0 = new ViewModel();
            ViewModel viewModel1 = new ViewModel();
            //ViewModel viewModel = MappingExtensions.ToViewModel(model, viewModel0);
            //ViewModel viewModel2 = MappingExtensions.ToViewModel(model, viewModel0);
            ViewModel viewModel = MappingExtensions.MapTo<Model, ViewModel>(model, viewModel0);
            //ViewModel viewModel2 = MappingExtensions.MapTo(model, viewModel0);
            ViewModel viewModel2 = MappingExtensions.MapTo<Model, ViewModel>(model);
            Console.WriteLine($"viewModel={viewModel}");
            Console.WriteLine($"viewModel={viewModel2}");

            viewModel2.Position.X = 10;
            Console.WriteLine($"viewModel={viewModel}");
            Console.WriteLine($"viewModel={viewModel2}");

            //ViewModel viewModel3= serviceProvider.GetRequiredService<ViewModel>();
            //ViewModel viewModel4= serviceProvider.GetRequiredService<ViewModel>();
            //Console.WriteLine($"viewModel={viewModel3}");
            //Console.WriteLine($"viewModel={viewModel4}");
            //viewModel3.Position.X = 110;
            //Console.WriteLine($"viewModel={viewModel3}");
            //Console.WriteLine($"viewModel={viewModel4}");

            Console.ReadKey();
        }


    }


}

