using System;
using System.Linq;
using Ioc_Help.Abstract;
using Ioc_Help.Concrete;
using Ninject;

namespace Ioc_Help.Infrastructure
{
    static public class NinjectModule
    {
        static public void Bindings(IKernel ninjectKernel)
        {
            ninjectKernel.Bind(typeof(IResolver<>)).To(typeof(Resolver<>));
        }
    }
}
