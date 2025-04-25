using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleAppTest.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(serviceProvider.GetService);

                #region
                cfg.CreateMap<Model, ViewModel>()
                //.ConstructUsingServiceLocator()
                .AfterMap((source, destination)=>destination.Position.X++);
                cfg.CreateMap<ViewModel, Model>()
                .AfterMap((source, destination) => destination.Position.X++);
                cfg.CreateMap<Position, Position>();
                cfg.CreateMap<Model, Model>();
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
