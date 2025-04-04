using AutoMapper;

namespace ConsoleAppTest.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                #region
                cfg.CreateMap<Model, ViewModel>()
                .AfterMap((source, destination)=>destination.Position.X++);
                cfg.CreateMap<ViewModel, Model>()
                .AfterMap((source, destination) => destination.Position.X++);
                cfg.CreateMap<Position, Position>(); 
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
