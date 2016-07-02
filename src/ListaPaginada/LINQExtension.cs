using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ListaPaginada
{
    public static class LINQExtension
    {
        public static ListaPaginada<T> ToListaPaginada<T>(this IEnumerable<T> source, int tamañoPagina, int numeroPagina)
        {
            return new ListaPaginada<T>(tamañoPagina, numeroPagina, source.ToList());
        }
    }
}
