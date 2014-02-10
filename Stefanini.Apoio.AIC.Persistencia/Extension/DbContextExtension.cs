using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.Entity
{
    public static class DbContextExtension
    {
        public static DbSet<T> DbGet<T>(this DbContext db) where T : class
        {
            Type type = db.GetType();
            DbSet<T> contexto = null;
            var dbSets = (from p in type.GetProperties()
                          where p.PropertyType.IsGenericType
                             && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)

                          select p.PropertyType.GetGenericArguments().First()
                          );

            foreach (var r in dbSets)
            {
                if (typeof(T).IsAssignableFrom(r))
                {
                    contexto = (DbSet<T>)type.GetProperty(r.Name).GetValue(db, null);
                }
            }

            return contexto;
        }

    }
}
