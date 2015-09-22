using System;
using System.Linq;

namespace Ioc_Help.Abstract
{
    public interface IResolver<T> where T : class
    {
        T Resolve();
    }
}
