using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class KamataController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveKamate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllKamate()
    {
        (bool isError, var kamate, ErrorMessage? error) = await DataProvider.GetAllKamate();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(kamate);
    }

    [HttpGet]
    [Route("UzmiKamatuPoIDju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetKamataByID(int id)
    {
        (bool isError, var kamata, ErrorMessage? error) = await DataProvider.GetKamataByID(id);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(kamata);
    }

    [HttpGet]
    [Route("UzmiKamatePoPredmetuObracuna/{predmetObracunaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetKamateByPredmetObracunaID(int predmetObracunaId)
    {
        (bool isError, var kamate, ErrorMessage? error) = await DataProvider.GetKamateByPredmetObracunaID(predmetObracunaId);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(kamate);
    }

    [HttpPost]
    [Route("DodajKamatu")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddKamata([FromBody] KamataView kv)
    {
        var data = await DataProvider.AddKamata(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno dodata kamata. ID: {kv.Id}");
    }

    [HttpPut]
    [Route("PromeniKamatu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateKamata([FromBody] KamataView kv)
    {
        var data = await DataProvider.UpdateKamata(kv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažurirana kamata. ID: {kv.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiKamatu/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteKamata(int id)
    {
        var data = await DataProvider.DeleteKamata(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisana kamata. ID: {id}");
    }
}
