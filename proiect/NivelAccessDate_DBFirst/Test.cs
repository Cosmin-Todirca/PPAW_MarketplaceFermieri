using Repository_DBFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer_DBFirst
{
    public class Test
    {
        static void Main(string[] args)
        {
            using (var context = new marketplace_fermieriEntities())
            {
                Console.WriteLine("--- Clienti ---");
                var clienti = context.client
                                    .ToList();
                AfisareColectie(clienti);

                Console.WriteLine("--- Vanzatori ---");
                var vanzatori = context.vanzator
                                    .ToList();
                AfisareColectie(vanzatori);



                Console.WriteLine("\n--- Produse ---");
                var produse = context.produs
                                    .Include(produs => produs.numeProdus)//de vazut ce face
                                    .ToList();
                AfisareColectie(produse);

                Console.WriteLine("\n--- Vanzatorul primului produs ---");
                Console.WriteLine(produse.FirstOrDefault().vanzatori.numeVanzator);
            }

            Console.ReadKey();
        }

        static void AfisareColectie<T>(List<T> colectie)
        {
            foreach (T item in colectie)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
