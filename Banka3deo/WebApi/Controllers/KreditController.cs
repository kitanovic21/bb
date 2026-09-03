using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class KreditController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveKredite")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllKrediti()
    {
        (bool isError, var krediti, ErrorMessage? error) = await DataProvider.GetAllKrediti();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(krediti);
    }

    [HttpGet]
    [Route("UzmiKreditPoIDju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetKreditByID(int id)
    {
        (bool isError, var kredit, ErrorMessage? error) = await DataProvider.GetKreditByID(id);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(kredit);
    }

    [HttpGet]
    [Route("UzmiKrediteKlijenta/{klijentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetKreditiByKlijentID(int klijentId)
    {
        (bool isError, var krediti, ErrorMessage? error) = await DataProvider.GetKreditiByKlijentID(klijentId);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(krediti);
    }

    [HttpPost]
    [Route("DodajKredit")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddKredit([FromBody] KreditView kv)
    {
        var data = await DataProvider.AddKredit(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno odobren kredit. ID: {kv.Id}");
    }

    [HttpPut]
    [Route("PromeniKredit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateKredit([FromBody] KreditView kv)
    {
        var data = await DataProvider.UpdateKredit(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažuriran kredit. ID: {kv.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiKredit/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteKredit(int id)
    {
        var data = await DataProvider.DeleteKredit(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisan kredit. ID: {id}");
    }
}
