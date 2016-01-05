namespace SzereloCegApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SzereloCegApp.DAL.SzereloCegEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SzereloCegApp.DAL.SzereloCegEntities context)
        {
            var szerelok = new List<Szerelo>
            {
                new Szerelo { Vezet�kn�v = "Nagy", Keresztn�v = "P�ter" },
                new Szerelo { Vezet�kn�v = "Kiss", Keresztn�v = "�ron" },
                new Szerelo { Vezet�kn�v = "Jo�", Keresztn�v = "G�bor" },
                new Szerelo { Vezet�kn�v = "Alex", Keresztn�v = "J�nos" }
            };
            szerelok.ForEach(s => context.Szerelok.AddOrUpdate(a => a.Keresztn�v, s));
            context.SaveChanges();

            var ugyfelek = new List<Ugyfel>
            {
                new Ugyfel { Vezet�kn�v = "N�meth", Keresztn�v = "G�bor", Szulido = DateTime.Parse("1990-01-01"), SzereloID =1, FelvetelIdeje = DateTime.Parse("2015-12-11"), Surgos = false },
                new Ugyfel { Vezet�kn�v = "Nagy", Keresztn�v = "Lajos", Szulido = DateTime.Parse("1980-07-21"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2015-12-20"), Surgos = false },
                new Ugyfel { Vezet�kn�v = "R�p�s", Keresztn�v = "Viktor", Szulido = DateTime.Parse("1970-03-20"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-05"), Surgos = false },
                new Ugyfel { Vezet�kn�v = "Oleg", Keresztn�v = "Ren�t�", Szulido = DateTime.Parse("1975-05-30"), SzereloID =4, FelvetelIdeje = DateTime.Parse("2015-11-11"), Surgos = true },
                new Ugyfel { Vezet�kn�v = "Franc", Keresztn�v = "B�le", Szulido = DateTime.Parse("1912-02-11"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-26"), Surgos = false },
                new Ugyfel { Vezet�kn�v = "Loo", Keresztn�v = "K�roly", Szulido = DateTime.Parse("1965-11-05"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2016-01-02"), Surgos = false },
                new Ugyfel { Vezet�kn�v = "Ollos", Keresztn�v = "Vilmos", Szulido = DateTime.Parse("1979-12-14"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-10-11"), Surgos = true }
            };
            ugyfelek.ForEach(s => context.Ugyfelek.AddOrUpdate(a => a.Vezet�kn�v, s));
            context.SaveChanges();

            var diagnosztikak = new List<Diagnosztika>
            {
                new Diagnosztika { HibaNeve = "Elektronika" },
                new Diagnosztika { HibaNeve = "�nind�t�" },
                new Diagnosztika { HibaNeve = "MotorHiba" },
                new Diagnosztika { HibaNeve = "Kerekek" },
                new Diagnosztika { HibaNeve = "H�t�s" },
                new Diagnosztika { HibaNeve = "�zemanyagrendszer" },
                new Diagnosztika { HibaNeve = "Kuplung - V�lt�" },
                new Diagnosztika { HibaNeve = "Karossz�ria" },
                new Diagnosztika { HibaNeve = "Alv�z" },
                new Diagnosztika { HibaNeve = "Olajcsere" }
            };
            diagnosztikak.ForEach(d => context.Diagnosztik�k.AddOrUpdate(b => b.HibaNeve, d));
            context.SaveChanges();

            var gepjarmuvek = new List<GepJarmu>
            {
                new GepJarmu { Marka = "Opel", Tipus = "Astra", GyartasiEv = DateTime.Parse("2010-01-01"),  Rendszam = "AGB-121", UgyfelID = 1},
                new GepJarmu { Marka = "Audi", Tipus = "A4", GyartasiEv = DateTime.Parse("1999-01-01"),  Rendszam = "HBD-123", UgyfelID = 2},
                new GepJarmu { Marka = "BMW", Tipus = "M4", GyartasiEv = DateTime.Parse("2000-01-01"),  Rendszam = "AWQ-663", UgyfelID = 3},
                new GepJarmu { Marka = "Fiat", Tipus = "Punto", GyartasiEv = DateTime.Parse("2001-01-01"),  Rendszam = "XAW-234", UgyfelID = 4},
                new GepJarmu { Marka = "Mitsubishi", Tipus = "Galant", GyartasiEv = DateTime.Parse("2013-01-01"),  Rendszam = "JRW-732", UgyfelID = 5},
                new GepJarmu { Marka = "Audi", Tipus = "R8", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-373", UgyfelID = 6},
                new GepJarmu { Marka = "BMW", Tipus = "X5", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-373", UgyfelID = 6},
                new GepJarmu { Marka = "Opel", Tipus = "Vectra", GyartasiEv = DateTime.Parse("1990-01-01"),  Rendszam = "HWW-723", UgyfelID = 7}
            };
            gepjarmuvek.ForEach(s => context.GepJarmuvek.AddOrUpdate(a => a.Rendszam, s));
            context.SaveChanges();

        }
    }
}
