using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate;
using FluentNHibernate.Automapping;
using SharpArch.Data.NHibernate.FluentNHibernate;
using SharpArch.Core.DomainModel;
using SimpleStore.Core;

namespace SimpleStore.Data.NHibernateMaps
{
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            var mappings = new AutoPersistenceModel();
            mappings.AddEntityAssembly(typeof(Site).Assembly).Where(GetAutoMappingFilter);
        //    mappings.Setup(GetSetup());
            mappings.IgnoreBase<Entity>();
            mappings.IgnoreBase(typeof(EntityWithTypedId<>));
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
            return mappings;
        }

        private Action<AutoMappingExpressions> GetSetup()
        {
            return c =>
            {
                c.FindIdentity = type => type.Name == (type.Name + "Id");
            };
        }

        /// <summary>
        /// Provides a filter for only including types which inherit from the IEntityWithTypedId interface.
        /// </summary>
        private bool GetAutoMappingFilter(Type t)
        {
            bool auto = t.GetInterfaces().Any(x =>
                 x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
            return auto;
        }
    }
}

