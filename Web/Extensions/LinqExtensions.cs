using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web.Extensions
{
    public static class LinqExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
        {
            return Task.Run(() => list.ToList());
        }
    }
}