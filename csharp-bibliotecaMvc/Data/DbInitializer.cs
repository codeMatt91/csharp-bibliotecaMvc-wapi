using csharp_bibliotecaMvc.Models;
using System;
using System.Linq;



namespace csharp_bibliotecaMvc.Data
{
    public class DbInitializer
    {
        public static void Initialize(BibliotecaContext context)
        {
            context.Database.EnsureCreated();  //crea il db se non c'è


            if (context.Utentes.Any())
            {
                return;   // DB has been seeded
            }

            var utenti = new Utente[]
            {
            new Utente{Nome="Matteo",Cognome="Imbimbo",Telefono="0153", Email="matteo.i@email.it",Password="12345"},
            new Utente{Nome="Marco",Cognome="Rossi",Telefono="4567", Email="marco.r@email.it",Password="89076", }
            };

            foreach (Utente u in utenti)
            {
                context.Utentes.Add(u);
            }
            context.SaveChanges();

            var autore = new Autori[]
        {
             new Autori{Nome="Daniel",Cognome="Defoe" },
             new Autori{Nome="J.K.",Cognome="Rollwing" },
             new Autori{Nome="Paulo",Cognome="Coelho"},
             new Autori{Nome="J.R.R.",Cognome="Tolkien"},

        };

            foreach (Autori a in autore)
            {
                context.Autoris.Add(a);
            }
            context.SaveChanges();

            // per popolare la tabella ponte
            var Defoe = context.Autoris.Where(item => item.Cognome == "Defoe").First();
            var Rollwing = context.Autoris.Where(item => item.Cognome == "Rollwing").First();
            var Coelho = context.Autoris.Where(item => item.Cognome == "Coelho").First();
            var Tolkien = context.Autoris.Where(item => item.Cognome == "Tolkien").First();

            var libri = new Libro[]
           {

                new Libro{Titolo="Robinson Crusoe",Settore="Romanzi",Autori=new List<Autori>{ Defoe }, Stato=Stato.Disponibile,Scaffale="002"},
                new Libro{Titolo="Harry Potter",Settore="FAntasi",Autori=new List<Autori>{ Rollwing },Stato=Stato.Disponibile,Scaffale="003"},
                new Libro{Titolo="Come il fiume che scorre",Settore="Romanzi",Autori=new List<Autori>{ Coelho },Stato=Stato.Disponibile,Scaffale="001"},
                new Libro{Titolo="Il signore degli anelli",Settore="Romanzi",Autori=new List<Autori>{ Tolkien },Stato=Stato.Disponibile,Scaffale="002"},
                new Libro{Titolo="Lo Hobbit",Settore="FAntasi",Autori=new List<Autori>{ Tolkien },Stato=Stato.Disponibile, Scaffale="001"},

           };

            foreach (Libro l in libri)
            {
                context.Libros.Add(l);
            }
            context.SaveChanges();



            var prestiti = new Prestito[]
         {
            new Prestito{PrestitoID=1,UtenteID=1,LibroID=3,Al=DateTime.Parse("2022-10-05"),Dal=DateTime.Parse("2022-11-05") },
            new Prestito{PrestitoID=2,UtenteID=2,LibroID=1,Al=DateTime.Parse("2021-05-05"),Dal=DateTime.Parse("2021-06-05") }

         };

            foreach (Prestito a in prestiti)
            {
                context.Prestitis.Add(a);
            }
            context.SaveChanges();




        }

    }
}
