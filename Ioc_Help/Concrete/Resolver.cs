using System;
using System.Linq;
using Ioc_Help.Abstract;
using Ninject;

namespace Ioc_Help.Concrete
{
    public class Resolver<T> : IResolver<T> where T : class
    {
        public Resolver(IKernel kernel)
        {
            m_kernel = kernel;
        }

        public T Resolve()
        {
            return m_kernel.Get<T>();
        }
        private readonly IKernel m_kernel;
    }
}
