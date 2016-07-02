using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaPaginada
{
    public class ListaPaginada<T> : IEnumerable<T>
    {
        public int TamañoPagina { get; private set; }
        public int TotalItem { get; private set; }
        public int PaginaActual { get; private set; }
        public bool EsPrimerPagina { get; private set; }
        public bool EsUltimaPagina { get; private set; }
        public int PrimerItemPagina { get; private set; }
        public int UltimoItemPagina { get; private set; }
        public int TotalDePaginas { get { return (int)Math.Ceiling((double)TotalItem / TamañoPagina); } }
        private List<T> Items { get; set; }
        private List<T> AllItems { get; set; }

        /// <summary>
        /// Retorna una lista organizada por paginas, con informacion relacionada a la pagina que se seleccionó.
        /// Todos los items del parámetro "items" se mantienen internamente pero solo se puede iterar en los que pertenecen a la pagina seleccionada.
        /// Para acceder a items de otras paginas se debe cambiar de pagina con el metodo CambiarPagina
        /// </summary>
        /// <param name="tamañoPagina">La cantidad de items por pagina.</param>
        /// <param name="numeroPagina">El numero de la pagina que se es iterable.</param>
        /// <param name="items">Colleccion a partir de la cual se crea la lista paginada.</param>
        public ListaPaginada(int tamañoPagina, int numeroPagina, IEnumerable<T> items)
        {
            Init(tamañoPagina, numeroPagina, items);
        }
        private void Init(int tamañoPagina, int numeroPagina, IEnumerable<T> items)
        {
            if (tamañoPagina * (numeroPagina - 1) >= items.Count())
                throw new ArgumentOutOfRangeException("numeroPagina", "La pagina " + numeroPagina + " no existe para el tamaño de pagina " + tamañoPagina + " y la cantidad de items de la coleccion");
            AllItems = items.ToList();
            Items = items.Skip(tamañoPagina * (numeroPagina - 1)).Take(tamañoPagina).ToList();
            TamañoPagina = tamañoPagina;
            PaginaActual = numeroPagina;
            TotalItem = items.Count();
            if (numeroPagina == 1)
            {
                EsPrimerPagina = true;
                PrimerItemPagina = 0;
                UltimoItemPagina = TotalItem >= TamañoPagina ? tamañoPagina - 1 : items.Count();
                EsUltimaPagina = TotalItem <= TamañoPagina;
            }
            else
            {
                EsPrimerPagina = false;
                PrimerItemPagina = (numeroPagina - 1) * TamañoPagina;//Si tengo 3 paginas de 10 items (items del 0 al 29) en la 2da tengo los item del 10 al 19, el primer item es el 10
                UltimoItemPagina = PrimerItemPagina + Items.Count() - 1;//El ultimo es 10 + 10 - 1 = 19
                EsUltimaPagina = (TotalItem - 1) == UltimoItemPagina;
            }
        }

        /// <summary>
        /// Permite cambiar la pagina que se puede iterar.
        /// </summary>
        /// <param name="pagina">Numero de pagina que se desea habilitar para iterar.</param>
        public void CambiarPagina(int pagina)
        {
            Init(TamañoPagina, pagina, AllItems);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }
        
    }
}