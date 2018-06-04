using System;
using System.Collections.Generic;
using System.Linq;
using Splat;

namespace Learn.Core.Common.Helpers
{
    public static class RegistrationHelper
    {
        /// <summary>
        /// Helper class for having a object's constructor automatically assigned by a "GetService" request.
        /// </summary>
        /// <param name="resolver">The resolver.</param>
        /// <param name="type">The type to register.</param>
        public static void Register<TConcrete, TInterface>(this IMutableDependencyResolver resolver)
            where TConcrete : class
        {
            var concreteType = typeof(TConcrete);

            // Must be a single constructor
            var constructors = concreteType.GetConstructors().Single();

            IList<object> values = new List<object>();

            foreach (var parameter in constructors.GetParameters())
            {
                if (parameter.ParameterType.IsInterface == false)
                {
                    throw new InvalidOperationException($"The type {concreteType.Name} has constructor paramters that are not interfaces.");
                }

                values.Add(resolver.GetService(parameter.ParameterType));
            }

            resolver.Register(() => Activator.CreateInstance(concreteType, values.ToArray()), typeof(TInterface));
        }

        /// <summary>
        /// Helper class for having a object's constructor automatically assigned by a "GetService" request.
        /// </summary>
        /// <param name="resolver">The resolver.</param>
        /// <param name="type">The type to register.</param>
        public static void Register<TConcrete>(this IMutableDependencyResolver resolver)
            where TConcrete : class
        {
            var concreteType = typeof(TConcrete);

            // Must be a single constructor
            var constructors = concreteType.GetConstructors().Single();

            IList<object> values = new List<object>();

            foreach (var parameter in constructors.GetParameters())
            {
                if (parameter.ParameterType.IsInterface == false)
                {
                    throw new InvalidOperationException($"The type {concreteType.Name} has constructor paramters that are not interfaces.");
                }

                values.Add(resolver.GetService(parameter.ParameterType));
            }

            resolver.Register(() => Activator.CreateInstance(concreteType, values.ToArray()), typeof(TConcrete));
        }
    }
}
