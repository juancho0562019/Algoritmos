using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public interface IFormFactory
    {
        T? Create<T>() where T : IFormBase;

        T? GetService<T>() where T : class;
    }
}
