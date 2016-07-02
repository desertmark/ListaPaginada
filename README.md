# ListaPaginada
Lista Paginada generica para desplegar datos en una tabla que tendrá un paginador.

example
Add the using statement:

Using ListaPaginada

then in your code supose you have a list of MyClass Objects

            var page = 1;
            var pageSize = 3;
            var source = new List<MyClass>()
            {
              //Some objects
            };
            var lista = source.ToListaPaginada<MyClass>(pageSize,page);

Or

            var lista = new ListaPaginada<MyClass>(pageSize,page,source);

Then

            Console.WriteLine(lista.EsPrimerPagina);  //true
            Console.WriteLine(lista.EsUltimaPagina);  //true if source has 3 or less items. false otherwise
            Console.WriteLine(lista.PrimerItemPagina);//0
            Console.WriteLine(lista.UltimoItemPagina);//2
            Console.WriteLine(lista.TotalItem);       //source.Count();
            Console.WriteLine(lista.PaginaActual);    //1
            Console.WriteLine(lista.TotalDePaginas);  //it will depend on how many items source has.

