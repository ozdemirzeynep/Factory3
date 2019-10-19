using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory3.Factories
{
    public class DataContextFactory<T> where T: new()
    {
        public T Instance { get; set; }

        public DataContextFactory()
        {
            Instance = new T();
        }
    }
}
