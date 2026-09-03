using Microsoft.AspNetCore.Mvc;
using BankaLibrary;
using BankaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DepozitController : ControllerBase
{
    [HttpGet]
    [Route("UzmiSveDepozite")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllDepoziti()
    {
        (bool isError, var depoziti, ErrorMessage? error) = await DataProvider.GetAllDepoziti();
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(depoziti);
    }

    [HttpGet]
    [Route("UzmiDepozitPoIDju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDepozitByID(int id)
    {
        (bool isError, var depozit, ErrorMessage? error) = await DataProvider.GetDepozitByID(id);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(depozit);
    }

    [HttpGet]
    [Route("UzmiDepoziteKlijenta/{klijentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetDepozitiByKlijentID(int klijentId)
    {
        (bool isError, var depoziti, ErrorMessage? error) = await DataProvider.GetDepozitiByKlijentID(klijentId);
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(depoziti);
    }

    [HttpPost]
    [Route("DodajDepozit")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddDepozit([FromBody] DepozitView dv)
    {
        var data = await DataProvider.AddDepozit(dv);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno otvoren depozit. ID: {dv.Id}");
    }

    [HttpPut]
    [Route("PromeniDepozit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDepozit([FromBody] DepozitView dv)
    {
        var data = await DataProvider.UpdateDepozit(dv);

        if (data.IsError)
        {
            return StatusCode(data.Error?.StatusCode ?? 400, data.Error?.Message);
        }

        return Ok($"Uspešno ažuriran depozit. ID: {dv.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiDepozit/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDepozit(int id)
    {
        var data = await DataProvider.DeleteDepozit(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno obrisan depozit. ID: {id}");
    }
}
