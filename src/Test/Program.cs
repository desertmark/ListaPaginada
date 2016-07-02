using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaPaginada;
namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var datos = new List<string>()
            {
                "Hola",
                "Como",
                "Estas",
                "Hoy",
                "?",
                "Todo",
                "Bien",
                "?"
            };

            var lista = datos.ToListaPaginada(3, 1);
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }            
            Console.WriteLine(lista.EsPrimerPagina);
            Console.WriteLine(lista.EsUltimaPagina);
            Console.WriteLine(lista.PrimerItemPagina);
            Console.WriteLine(lista.UltimoItemPagina);
            Console.WriteLine(lista.TotalItem);
            Console.WriteLine(lista.PaginaActual);
            Console.WriteLine(lista.TotalDePaginas);

            Console.WriteLine("");
            Console.WriteLine("Siguiente pagina");
            Console.WriteLine("");

            lista.CambiarPagina(2);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(lista.EsPrimerPagina);
            Console.WriteLine(lista.EsUltimaPagina);
            Console.WriteLine(lista.PrimerItemPagina);
            Console.WriteLine(lista.UltimoItemPagina);
            Console.WriteLine(lista.TotalItem);
            Console.WriteLine(lista.PaginaActual);
            Console.WriteLine(lista.TotalDePaginas);
            Console.ReadKey();
        }
    }
}
