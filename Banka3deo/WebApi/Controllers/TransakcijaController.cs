using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransakcijaController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveTransakcije")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllTransakcije()
    {
        (bool isError, var transakcije, ErrorMessage? error) = await DataProvider.GetAllTransakcije();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(transakcije);
    }

    [HttpGet]
    [Route("UzmiTransakcijuPoIDju/{kodTransakcije}/{brojRacuna}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetTransakcijaByID(int kodTransakcije, string brojRacuna)
    {
        (bool isError, var transakcija, ErrorMessage? error) = await DataProvider.GetTransakcijaByID(kodTransakcije,brojRacuna);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(transakcija); 
    }

    [HttpGet]
    [Route("UzmiSveTransakcijeSaRacuna/{brojRacuna}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllTransakcijeByRacun(string brojRacuna)
    {
        
        (bool isError, var transakcija, ErrorMessage? error) = await DataProvider.GetTransakcijeByRacun(brojRacuna);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(transakcija);
    }

    [HttpPost]
    [Route("DodajTransakciju")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddTransakcija([FromBody] TransakcijeView tv)
    {
        var data = await DataProvider.AddTransakcija(tv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno dodata transakcija. Kod Transakcije: {tv.KodTransakcije}\nBroj Racuna Posiljaoca: {tv.BrojRacunaPosiljalac}");
    }

    [HttpPut]
    [Route("PromeniTransakciju")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateTransakcija([FromBody] TransakcijeView tv)
    {
        var data = await DataProvider.UpdateTransakcija(tv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažurirana transakcija. Kod Transakcije: {tv.KodTransakcije}\nBroj Racuna Posiljaoca: {tv.BrojRacunaPosiljalac}");
    }

    [HttpDelete]
    [Route("IzbrisiTransakciju/{kodTransakcije}/{brojRacuna}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteTransakcija(int kodTransakcije, string brojRacuna)
    {
        var data = await DataProvider.DeleteTransakcija(kodTransakcije, brojRacuna);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisana transakcija. KodTransakcije: {kodTransakcije}\nBroj Racuna Posiljaoca: {brojRacuna}");
    }
}