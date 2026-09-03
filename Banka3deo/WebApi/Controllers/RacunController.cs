using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RacunController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveRacune")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllRacuni()
    {
        (bool isError, var racuni, ErrorMessage? error) = await DataProvider.GetAllRacuni();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(racuni);
    }

    [HttpGet]
    [Route("UzmiRacunPoBroju/{brojRacuna}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetRacunByBroj(string brojRacuna)
    {
        (bool isError, var racun, ErrorMessage? error) = await DataProvider.GetRacunByBroj(brojRacuna);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(racun);
    }

    [HttpGet]
    [Route("UzmiRacuneKlijenta/{klijentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetRacuniByKlijentID(int klijentId)
    {
        (bool isError, var racuni, ErrorMessage? error) = await DataProvider.GetRacuniByKlijentID(klijentId);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(racuni);
    }

    [HttpPost]
    [Route("DodajRacun")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddRacun([FromBody] RacunView rv)
    {
        var data = await DataProvider.AddRacun(rv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno otvoren račun. Broj računa: {rv.BrojRacuna}, Tip: {rv.TipRacuna}");
    }

    [HttpPut]
    [Route("PromeniRacun")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateRacun([FromBody] RacunView rv)
    {
        var data = await DataProvider.UpdateRacun(rv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažuriran račun. Broj računa: {rv.BrojRacuna}");
    }

    [HttpDelete]
    [Route("IzbrisiRacun/{brojRacuna}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteRacun(string brojRacuna)
    {
        var data = await DataProvider.DeleteRacun(brojRacuna);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisan račun. Broj računa: {brojRacuna}");
    }
}