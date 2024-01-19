using BusinessLayer_DBFirst;
using NivelAccessDate_DBFirst;
//using Repository_CodeFirst;
using Repository_DBFirst;
using System;
using System.Collections.Generic;
using ViewModels;


namespace TestORM_SchemaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientServices c1 = new ClientServices(new marketplace_fermieriEntities(), new MemoryCacheService());
            ReadClientViewModel c2 = c1.Get(1);
            Console.WriteLine(c2.idClient + " " + c2.numeClient + " " + c2.prenumeClient + " " + c2.email + " " + c2.numarTelefon);

            VanzatorServices v1 = new VanzatorServices(new marketplace_fermieriEntities());
            ReadVanzatorViewModel v2 = v1.Get(1);
            Console.WriteLine(v2.idVanzator + " " + v2.numeVanzator + " " + v2.prenumeVanzator + " " + v2.email + " " + v2.numarTelefon);

            ProdusServices p1 = new ProdusServices(new marketplace_fermieriEntities());
            ReadProdusViewModel p2 = p1.Get(1);
            Console.WriteLine(p2.idProdus + " " + p2.idVanzator + " " + p2.numeProdus + " " + p2.descriereProdus + " " + p2.pret + " " + p2.unitateDeMasura + " " + p2.cantitate + " " + p2.imagine);

            ReadProdusCuVanzatorViewModel p3 = p1.GetProdusCuVanzator(1);
            Console.WriteLine(p3.idProdus + " " + p3.idVanzator + " " + p3.numeProdus + " " + p3.descriereProdus + " "
                + p3.pret + " " + p3.unitateDeMasura + " " + p3.cantitate + " " + p3.imagine + " "
                + p3.vanzator.numeVanzator);

            ReadProdusCuVanzatorViewModel produs = p1.GetProdusCuVanzator(1);
            Console.WriteLine(produs.vanzator.numeVanzator);

            List<ReadVanzatorViewModel> vanzators = v1.GetAll();
            foreach (var i in vanzators)
                Console.Write(i.numeVanzator + " ");
            Console.WriteLine();

            /*
            using (var context = new marketplace_fermieriEntities())
            {
                Console.WriteLine("--- Clienti ---");
                var clienti = context.clienti
                                    .ToList();
                AfisareColectie(clienti);

                Console.WriteLine("--- Vanzatori ---");
                var vanzatori = context.vanzatori
                                    .ToList();
                AfisareColectie(vanzatori);



                Console.WriteLine("\n--- Produse ---");
                var produse = context.produse
                                    .Include(produs => produs.numeProdus)//de vazut ce face
                                    .ToList();
                AfisareColectie(produse);

                Console.WriteLine("\n--- Vanzatorul primului produs ---");
                Console.WriteLine(produse.FirstOrDefault().vanzatori.numeVanzator);
            }
            */

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
