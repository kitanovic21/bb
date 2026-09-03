using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SigurnosnaKontrolaController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveDogadjaje")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllSigurnosnaKontrole()
    {
        (bool isError, var dogadjaji, ErrorMessage? error) = await DataProvider.GetAllSigurnosnaKontrole();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(dogadjaji);
    }

    [HttpGet]
    [Route("UzmiDogadjajPoIDju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSigurnosnaKontrolaByID(int id)
    {
        (bool isError, var dogadjaj, ErrorMessage? error) = await DataProvider.GetSigurnosnaKontrolaByID(id);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(dogadjaj);
    }

    [HttpGet]
    [Route("UzmiDogadjajeKlijenta/{klijentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetSigurnosnaKontroleByKlijentID(int klijentId)
    {
        (bool isError, var dogadjaji, ErrorMessage? error) = await DataProvider.GetSigurnosnaKontroleByKlijentID(klijentId);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(dogadjaji);
    }

    [HttpPost]
    [Route("DodajDogadjaj")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddSigurnosnaKontrola([FromBody] SigurnosnaKontrolaView skv)
    {
        var data = await DataProvider.AddSigurnosnaKontrola(skv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno zabeležen događaj sigurnosne kontrole. ID: {skv.Id}");
    }

    [HttpPut]
    [Route("PromeniDogadjaj")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSigurnosnaKontrola([FromBody] SigurnosnaKontrolaView skv)
    {
        var data = await DataProvider.UpdateSigurnosnaKontrola(skv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažuriran događaj sigurnosne kontrole. ID: {skv.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiDogadjaj/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSigurnosnaKontrola(int id)
    {
        var data = await DataProvider.DeleteSigurnosnaKontrola(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisan događaj sigurnosne kontrole. ID: {id}");
    }
}
