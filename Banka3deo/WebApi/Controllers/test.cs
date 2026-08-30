using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Banka.Entiteti; // Promeni ako se tvoj namespace zove drugačije
using ISession = NHibernate.ISession;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ISession _session;

        // Kroz konstruktor "ubrizgavamo" NHibernate sesiju koju smo podesili u Program.cs
        public TestController(ISession session)
        {
            _session = session;
        }

        [HttpGet("ProveriKonekciju")]
        public IActionResult ProveriKonekciju()
        {
            try
            {
                // Pokušavamo da napravimo prost upit ka bazi. 
                // Zavisno od toga šta si napravio u BankaLibrary, stavi taj entitet ovde (npr. Klijent)
                var klijenti = _session.Query<Klijent>().ToList();
                
                return Ok($"Uspešno povezano! Pronađeno {klijenti.Count} redova u tabeli.");
            }
            catch (Exception ex)
            {
                // Ako pukne konekcija ili mapiranje nije dobro, ispisaće se tačan razlog
                return BadRequest($"Greška pri povezivanju sa Oracle bazom: {ex.Message} \nDetalji: {ex.InnerException?.Message}");
            }
        }
    }
}