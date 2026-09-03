using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;


namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class KlijentController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveKlijente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllKlijenti()
    {
        (bool isError, var klijenti, ErrorMessage? error) = await DataProvider.GetAllKlijenti();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(klijenti);
    }

    [HttpGet]
    [Route("UzmiKlijentaPoIDju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetKlijentByID(int id)
    {
        (bool isError, var klijent, ErrorMessage? error) = await DataProvider.GetKlijentByID(id);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(klijent);
    }

    [HttpPost]
    [Route("DodajKlijenta")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddKlijent([FromBody] KlijentView kv)
    {
        var data = await DataProvider.AddKlijent(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno dodat klijent. ID: {kv.ID}, Tip: {kv.TipKlijenta}");
    }

    [HttpPut]
    [Route("PromeniKlijenta")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateKlijent([FromBody] KlijentView kv)
    {
        var data = await DataProvider.UpdateKlijent(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažuriran klijent. ID: {kv.ID}");
    }

    [HttpDelete]
    [Route("IzbrisiKlijenta/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteKlijent(int id)
    {
        var data = await DataProvider.DeleteKlijent(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisan klijent. ID: {id}");
    }
}