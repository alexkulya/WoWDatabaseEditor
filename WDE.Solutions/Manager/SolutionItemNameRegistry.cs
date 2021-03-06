﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDE.Common;
using WDE.Module.Attributes;
using WDE.Common.Solution;

namespace WDE.Solutions.Manager
{
    [AutoRegister]
    public class SolutionItemNameRegistry : ISolutionItemNameRegistry
    {
        private Dictionary<Type, object> nameProviders = new Dictionary<Type, object>();

        public SolutionItemNameRegistry(IEnumerable<ISolutionNameProvider> providers)
        {
            // handy trick with (dynamic) cast, thanks to this proper Generic method will be called!
            foreach (var provider in providers)
                Register((dynamic)provider);
        }

        private void Register<T>(ISolutionNameProvider<T> provider) where T : ISolutionItem
        {
            nameProviders.Add(typeof(T), provider);
        }

        private string GetName<T>(T item) where T : ISolutionItem
        {
            var x = nameProviders[item.GetType()] as ISolutionNameProvider<T>;
            return x.GetName(item);
        }

        public string GetName(ISolutionItem item)
        {
            return GetName((dynamic)item);
        }
    }
}
