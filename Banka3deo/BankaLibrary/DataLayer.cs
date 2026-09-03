using BankaLibrary.Mapiranja;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary
{
    public class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                .Dialect<NHibernate.Dialect.Oracle12cDialect>() // dodato zbog id auto inkrementa
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19693;Password=19693sifra"));


            try
            {
                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<KlijentMap>())
                    // Isto podešavanje kao u Program.cs: zaobilazi .NET 10 bug sa
                    // MemberwiseClone/internal klasama u NHibernate proxy validatoru.
                    // Bez ovoga, svaki lazy-load/proxy (References, Fetch...) puca,
                    // pa CRUD operacije u DataProvider-u ne rade.
                    .ExposeConfiguration(c => c.SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, "false"))
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                // Ne gutamo pravu grešku (kao ranije preko BadRequest -> NotImplementedException),
                // nego je prosleđujemo dalje da bi se u DataProvider/kontroleru video pravi uzrok.
                throw new InvalidOperationException(
                    $"Neuspešno kreiranje NHibernate SessionFactory-ja: {e.Message}", e);
            }
        }
    }
}