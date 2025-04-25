using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Mapper
{
    public class AutoMapperStartupTask
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMapperStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute()
        {
            AutoMapperConfiguration.Init(_serviceProvider);
        }
    }
}
