using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Mapper
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region     
        public static ViewModel ToViewModel(this Model entity)
        {
            return entity.MapTo<Model, ViewModel>();
        }

        public static Model ToModel(this ViewModel model)
        {
            return model.MapTo<ViewModel, Model>();
        }
        #endregion
    }
}
